using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Interfaces.IRepository
{
    public interface IActivityRepository
    {
        Guid StartActivity(StartActivityRequest startActivityRequest, int userId);

        bool EndActivity(EndActivityRequest endActivityRequest, int userId);

        List<GetAllActivityResponse> GetAllActivity();

    }
}
