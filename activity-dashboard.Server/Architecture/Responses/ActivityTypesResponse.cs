namespace activity_dashboard.Server.Architecture.Responses
{
    public class ActivityTypesResponse
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public string ButtonCss { get; set; }

        public bool IsDisabled { get; set; } = false;
    }
}
