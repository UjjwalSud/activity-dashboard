using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Implementation.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        IActivityTypeRepository _activityTypeRepository;

        public ActivityTypeService(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        public ReturnResponse GetAllActiveActivityTypes()
        {
            return new ReturnResponse { isSuccessful = true, Data = _activityTypeRepository.GetAllActiveActivityTypes() };
        }
    }
}
