using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class ChatService : IChatService
    {
        private readonly EPortfolioDbContext dbContext;

        public ChatService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
