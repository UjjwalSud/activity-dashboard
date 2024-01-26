using activity_dashboard.Server.Architecture.DbModels;
using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Implementation.Repository
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        static readonly List<ActivityTypes> ActivityTypes;
        static ActivityTypeRepository()
        {
            if (ActivityTypes == null)
            {
                ActivityTypes = [];
                ActivityTypes.Add(new ActivityTypes
                {
                    Id = 1,
                    ActivityName = "ON BREAK",
                    ActivityDescription = "",
                    IsActive = true,
                    ButtonCss = "btn-primary",
                });
                ActivityTypes.Add(new ActivityTypes
                {
                    Id = 2,
                    ActivityName = "ON CALL",
                    ActivityDescription = "",
                    IsActive = true,
                    ButtonCss = "btn-secondary",
                });
                ActivityTypes.Add(new ActivityTypes
                {
                    Id = 3,
                    ActivityName = "IN MEETING",
                    ActivityDescription = "",
                    IsActive = true,
                    ButtonCss = "btn-success",
                });
                ActivityTypes.Add(new ActivityTypes
                {
                    Id = 3,
                    ActivityName = "NO TASK",
                    ActivityDescription = "",
                    IsActive = false,
                    ButtonCss = "btn-primary",
                });
            }
        }
        public List<ActivityTypesResponse> GetAllActiveActivityTypes()
        {
            return ActivityTypes.Where(x => x.IsActive).Select(x => new ActivityTypesResponse
            {
                Id = x.Id,
                ActivityName = x.ActivityName,
                ActivityDescription = x.ActivityDescription,
                ButtonCss = x.ButtonCss,
            }).ToList();
        }
    }
}
