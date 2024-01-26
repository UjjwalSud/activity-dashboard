namespace activity_dashboard.Server.Architecture.Responses
{
    public class ReturnResponse
    {       
        public bool isSuccessful { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
