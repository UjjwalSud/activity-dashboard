namespace activity_dashboard.Server.Architecture.Interfaces.IRepository
{
    public interface IActivityTypeRepository
    {
        List<DbModels.ActivityTypes> GetAllActiveActivityTypes();
    }
}
