using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Interfaces.IRepository
{
    public interface IActivityTypeRepository
    {
        List<ActivityTypesResponse> GetAllActiveActivityTypes();
    }
}
