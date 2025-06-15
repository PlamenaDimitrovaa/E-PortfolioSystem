using Hangfire.Dashboard;

namespace E_PortfolioSystem.Web.Infrastructure.Filters
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            return httpContext.User.IsInRole("Administrator");
        }
    }
} 