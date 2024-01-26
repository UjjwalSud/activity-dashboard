using activity_dashboard.Server.Architecture.Responses;

namespace activity_dashboard.Server.Architecture.Interfaces.IServices
{
    public interface IActivityTypeService
    {
        ReturnResponse GetAllActiveActivityTypes();
    }
}
