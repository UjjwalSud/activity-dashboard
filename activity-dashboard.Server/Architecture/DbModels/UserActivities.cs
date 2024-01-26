using activity_dashboard.Server.Architecture.Enums;

namespace activity_dashboard.Server.Architecture.DbModels
{
    public class UserActivities
    {
        public Guid Id { get; set; }
        public int UserId {  get; set; }
        public int ActivityTypeId { get; set; }
        public DateTime ActivityStartedAt { get; set; }
        public DateTime? ActivityEndedAt { get; set;}

        public ActivityStatus ActivityStatus { get; set; }
    }
}
