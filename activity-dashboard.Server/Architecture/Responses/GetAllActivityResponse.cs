using System.Text.Json.Serialization;

namespace activity_dashboard.Server.Architecture.Responses
{
    public class GetAllActivityResponse
    {
        public Guid ActivityId { get; set; }
        public int ActivityTypeId { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
        public string UserDetails { get; set; }
        public string ActivityName { get; set; }
        public DateTime ActivityStartedAt { get; set; }
        public DateTime? ActivityEndedAt { get; set;}
        public Enums.ActivityStatus ActivityStatus { get; set; }

    }
}
