using Microsoft.AspNetCore.SignalR;
using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Services.Data.Interfaces;
using System.Security.Claims;

namespace E_PortfolioSystem.Web.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;
        private static readonly Dictionary<string, string> UserConnections = new();

        public ChatHub(IChatService chatService)
        {
            this.chatService = chatService;
        }

        private string GetUserId()
        {
            return Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? 
                throw new InvalidOperationException("User not authenticated");
        }

        public override async Task OnConnectedAsync()
        {
            var userId = GetUserId();
            UserConnections[userId] = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = GetUserId();
            UserConnections.Remove(userId);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = GetUserId();

            var chatMessage = new ChatMessage
            {
                SenderId = Guid.Parse(senderId),
                ReceiverId = Guid.Parse(receiverId),
                Content = message,
                Timestamp = DateTime.UtcNow,
                IsRead = false
            };

            await chatService.SaveMessageAsync(chatMessage);

            if (UserConnections.TryGetValue(receiverId, out string? receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", senderId, message, chatMessage.Timestamp);
            }

            await Clients.Caller.SendAsync("ReceiveMessage", senderId, message, chatMessage.Timestamp);
        }

        public async Task MarkAsRead(string otherUserId)
        {
            var currentUserId = GetUserId();
            await chatService.MarkMessagesAsReadAsync(currentUserId, otherUserId);
        }
    }
} 