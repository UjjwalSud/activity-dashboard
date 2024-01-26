using activity_dashboard.Server.Architecture.DbModels;
using activity_dashboard.Server.Architecture.Interfaces.IRepository;

namespace activity_dashboard.Server.Architecture.Implementation.Repository
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        static readonly List<ActivityTypes> ActivityTypes;
        static ActivityTypeRepository()
        {
            if (ActivityTypes == null)
            {
                ActivityTypes = new List<ActivityTypes>();
                ActivityTypes.Add(new ActivityTypes { Id = 1, ActivityName = "A", ActivityDescription = "", IsActive = true });
                ActivityTypes.Add(new ActivityTypes { Id = 2, ActivityName = "B", ActivityDescription = "", IsActive = true });
                ActivityTypes.Add(new ActivityTypes { Id = 3, ActivityName = "C", ActivityDescription = "", IsActive = true });
                ActivityTypes.Add(new ActivityTypes { Id = 3, ActivityName = "D", ActivityDescription = "", IsActive = false });
            }
        }
        public List<ActivityTypes> GetAllActiveActivityTypes()
        {
            return ActivityTypes.Where(x => x.IsActive).ToList();
        }
    }
}
