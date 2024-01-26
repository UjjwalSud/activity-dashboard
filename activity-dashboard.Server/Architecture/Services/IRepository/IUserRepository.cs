using activity_dashboard.Server.Architecture.DbModals;
using activity_dashboard.Server.Architecture.Requests;

namespace activity_dashboard.Server.Architecture.Services.IRepository
{
    public interface IUserRepository
    {
        Users UserLogin(TokenRequest tokenRequest);
    }
}
