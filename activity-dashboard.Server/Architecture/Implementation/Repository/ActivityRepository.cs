using activity_dashboard.Server.Architecture.DbModels;
using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Implementation.Repository
{
    public class ActivityRepository : IActivityRepository
    {
        static readonly List<UserActivities> UserActivities;
        static ActivityRepository()
        {
            UserActivities ??= [];
        }

        public Guid StartActivity(StartActivityRequest startActivityRequest, int userId)
        {
            var exists = UserActivities.Any(x => x.UserId == userId && x.ActivityStatus == Enums.ActivityStatus.Started);
            if (exists)
            {
                return Guid.Empty;
            }
            UserActivities prp;
            UserActivities.Add(prp = new UserActivities
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ActivityTypeId = startActivityRequest.ActivityTypeId,
                ActivityStartedAt = DateTime.UtcNow,
                ActivityStatus = Enums.ActivityStatus.Started
            });
            return prp.Id;

        }
        public bool EndActivity(EndActivityRequest endActivityRequest, int userId)
        {
            var currentActivity = UserActivities.SingleOrDefault(x => x.Id == endActivityRequest.ActivityId);
            if (currentActivity != null && currentActivity.ActivityStatus == Enums.ActivityStatus.Started)
            {
                currentActivity.ActivityEndedAt = DateTime.UtcNow;
                currentActivity.ActivityStatus = Enums.ActivityStatus.Finished;
                return true;
            }
            return false;
        }

        public List<GetAllActivityResponse> GetStartedActivities()
        {
            return UserActivities.Where(x => x.ActivityStatus == Enums.ActivityStatus.Started).Select(x => new GetAllActivityResponse
            {
                ActivityId = x.Id,
                ActivityTypeId = x.ActivityTypeId,
                UserId = x.UserId,
                UserDetails = "",
                ActivityName = "",
                ActivityStartedAt = x.ActivityStartedAt,
                ActivityEndedAt = x.ActivityEndedAt,
                ActivityStatus = x.ActivityStatus,
            }).ToList();
        }
    }
}
