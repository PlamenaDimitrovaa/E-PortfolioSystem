namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface ITeacherService
    {
        Task<string> GetTeacherIdByUserIdAsync(string userId);
        string GetTeacherIdByUserId(string userId);
        Task CreateTeacherAsync(Guid userId);
    }
}
