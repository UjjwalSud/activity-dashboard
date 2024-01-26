using activity_dashboard.Server.Architecture.Requests;

namespace activity_dashboard.Server.Architecture.Interfaces.IRepository
{
    public interface IUserActivityLogRepository
    {
        Guid AssignNewActivityToUser(AssignNewActivityToUserRequest assignNewActivityToUserRequest);
    }
}
