using activity_dashboard.Server.Architecture.Enums;

namespace activity_dashboard.Server.Architecture.DbModels
{
    public class UserActivityLog
    {
        public int Id { get; set; }
        public int UserId {  get; set; }
        public int ActivityId { get; set; }
        public DateTime ActivityStartedAt { get; set; }
        public DateTime ActivityEndedAt { get; set;}

        public ActivityStatus ActivityStatus { get; set; }
    }
}
