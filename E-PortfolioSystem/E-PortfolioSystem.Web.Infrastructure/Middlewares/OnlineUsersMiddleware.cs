using E_PortfolioSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;

namespace E_PortfolioSystem.Web.Infrastructure.Middlewares
{
    public class OnlineUsersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string cookieName;
        private readonly int lastActivityMinutes;

        private static readonly ConcurrentDictionary<string, bool> AllKeys =
            new ConcurrentDictionary<string, bool>();

        public OnlineUsersMiddleware(RequestDelegate next,
            string cookieName = usersCookie,
            int lastActivityMinutes = LastActivityBeforeOfflineMinutes)
        {
            this.next = next;
            this.cookieName = cookieName;
            this.lastActivityMinutes = lastActivityMinutes;
        }

        public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                var userId = context.User.GetId()!;

                // Винаги обновяваме cookie-то при всяка заявка
                context.Response.Cookies.Append(this.cookieName, userId, new CookieOptions() 
                { 
                    HttpOnly = true, 
                    MaxAge = TimeSpan.FromDays(30) 
                });

                // Директно добавяме или обновяваме статуса на потребителя
                AllKeys.AddOrUpdate(userId, true, (key, oldValue) => true);

                memoryCache.GetOrCreate(userId, cacheEntry =>
                {
                    cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(this.lastActivityMinutes);
                    cacheEntry.RegisterPostEvictionCallback(this.RemoveKeyWhenExpired);
                    return string.Empty;
                });
            }
            else
            {
                if (context.Request.Cookies.TryGetValue(this.cookieName, out string userId))
                {
                    AllKeys.TryRemove(userId, out _);
                    context.Response.Cookies.Delete(this.cookieName);
                }
            }

            return this.next(context);
        }

        public static bool CheckIfUserIsOnline(string userId)
        {
            return AllKeys.ContainsKey(userId);
        }

        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string userId = (string)key;
            AllKeys.TryRemove(userId, out _);
        }
    }
}
