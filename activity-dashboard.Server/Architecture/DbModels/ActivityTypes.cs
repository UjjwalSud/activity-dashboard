namespace activity_dashboard.Server.Architecture.DbModels
{
    public class ActivityTypes
    {
        public int Id { get; set; }
        public string ActivityName {  get; set; }
        public string ActivityDescription { get; set; }
        public bool IsActive { get; set; }
    }
}
