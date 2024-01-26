using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Implementation.Services
{
    public class ActivityService : IActivityService
    {
        IActivityRepository _activityRepository;
        ICurrentUserService _currentUserService;
        IActivityTypeRepository _activityTypeRepository;
        IUserRepository _userRepository;

        public ActivityService(IActivityRepository activityRepository, ICurrentUserService currentUserService
            , IActivityTypeRepository activityTypeRepository, IUserRepository userRepository)
        {
            _activityRepository = activityRepository;
            _currentUserService = currentUserService;
            _activityTypeRepository = activityTypeRepository;
            _userRepository = userRepository;
        }

        public ReturnResponse StartActivity(StartActivityRequest startActivityRequest)
        {
            var result = _activityRepository.StartActivity(startActivityRequest, _currentUserService.UserId);
            if (result == Guid.Empty)
            {
                return new ReturnResponse { isSuccessful = false, Message = "There is already activity started. Please enter before starting it" };
            }
            return new ReturnResponse { Data = result, isSuccessful = true, Message = "Activity Started" };
        }

        public ReturnResponse EndActivity(EndActivityRequest endActivityRequest)
        {
            var result = _activityRepository.EndActivity(endActivityRequest, _currentUserService.UserId);
            if (result)
            {
                return new ReturnResponse { isSuccessful = true, Message = "Activity ended successfully" };
            }
            return new ReturnResponse { isSuccessful = false, Message = "Either activity already ended or dose not exists" };
        }

        public ReturnResponse GetStartedActivities()
        {
            var result = _activityRepository.GetStartedActivities();
            if (result.Count > 0)
            {
                var activityTypes = _activityTypeRepository.GetAllActiveActivityTypes();
                var users = _userRepository.GetAllUsers();
                result.ForEach(a =>
                {
                    a.ActivityName = activityTypes.Single(x => x.Id == a.ActivityTypeId).ActivityName;
                    a.UserDetails = users.Where(x => x.Id == a.UserId).Select(y => y.Name + " (" + y.Name + ")").Single();
                });
            }
            return new ReturnResponse { Data = result, isSuccessful = true };
        }

        public ReturnResponse GetUserStartedActivity()
        {
            var result = _activityRepository.GetStartedActivities().FirstOrDefault(x => x.UserId == _currentUserService.UserId);
            if (result != null)
            {
                var activityTypes = _activityTypeRepository.GetAllActiveActivityTypes();
                var users = _userRepository.GetAllUsers();
                result.ActivityName = activityTypes.Single(x => x.Id == result.ActivityTypeId).ActivityName;
                result.UserDetails = users.Where(x => x.Id == result.UserId).Select(y => y.Name + " (" + y.Name + ")").Single();
            }
            else
            {
                result = new GetAllActivityResponse();
            }
            return new ReturnResponse { Data = result, isSuccessful = true };
        }
    }
}
