using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Interfaces.IServices
{
    public interface IActivityService
    {
        ReturnResponse StartActivity(StartActivityRequest startActivityRequest);
        ReturnResponse EndActivity(EndActivityRequest endActivityRequest);
        ReturnResponse GetAllActivity();
    }
}
