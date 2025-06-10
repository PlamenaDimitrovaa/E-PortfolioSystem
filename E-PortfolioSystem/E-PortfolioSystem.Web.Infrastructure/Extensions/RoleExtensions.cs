using static E_PortfolioSystem.Common.GeneralApplicationConstants;

namespace E_PortfolioSystem.Web.Infrastructure.Extensions
{
    public static class RoleExtensions
    {
        public static string ToFriendlyName(this string role)
        {
            return role switch
            {
                AdminRoleName => "Администратор",
                TeacherRoleName => "Преподавател",
                StudentRoleName => "Студент",
                HRRoleName => "HR Специалист",
                _ => role
            };
        }
    }
} 