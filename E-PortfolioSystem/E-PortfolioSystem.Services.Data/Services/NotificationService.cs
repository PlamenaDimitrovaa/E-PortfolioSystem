using E_PortfolioSystem.Data;
using E_PortfolioSystem.Services.Data.Interfaces;

namespace E_PortfolioSystem.Services.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EPortfolioDbContext dbContext;

        public NotificationService(EPortfolioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
