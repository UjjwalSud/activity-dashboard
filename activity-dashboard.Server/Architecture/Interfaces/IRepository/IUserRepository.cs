using activity_dashboard.Server.Architecture.DbModels;
using activity_dashboard.Server.Architecture.Requests;

namespace activity_dashboard.Server.Architecture.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Users UserLogin(TokenRequest tokenRequest);
    }
}
