using System.Security.Claims;
using static E_PortfolioSystem.Common.GeneralApplicationConstants;

namespace E_PortfolioSystem.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
        public static bool IsStudent(this ClaimsPrincipal user)
        {
            return user.IsInRole(StudentRoleName);
        }
        public static bool IsTeacher(this ClaimsPrincipal user)
        {
            return user.IsInRole(TeacherRoleName);
        }
        public static bool IsHR(this ClaimsPrincipal user)
        {
            return user.IsInRole(HRRoleName);
        }
    }
}
