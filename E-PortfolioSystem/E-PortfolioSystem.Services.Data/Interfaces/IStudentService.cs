namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface IStudentService
    {
        Task<string> GetStudentIdByUserId(string userId);
    }
}
