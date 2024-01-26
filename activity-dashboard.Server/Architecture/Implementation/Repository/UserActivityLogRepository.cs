using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Requests;

namespace activity_dashboard.Server.Architecture.Implementation.Repository
{
    public class UserActivityLogRepository : IUserActivityLogRepository
    {
        public Guid AssignNewActivityToUser(AssignNewActivityToUserRequest assignNewActivityToUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}
