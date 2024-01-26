using activity_dashboard.Server.Architecture.Interfaces.IServices;
using System.Security.Claims;

namespace activity_dashboard.Server.Architecture.Implementation.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessors)
        {
            UserId = Convert.ToInt32(httpContextAccessors.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public int UserId { get; }

    }
}
