using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Services.IServices
{
    public interface ILoginService
    {
        ReturnResponse LoginAsync(TokenRequest model);
    }
}
