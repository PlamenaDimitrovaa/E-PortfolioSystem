namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IStudentService
    {
        Task<string> GetStudentIdByUserIdAsync(string userId);
        string GetStudentIdByUserId(string userId);
    }
}
