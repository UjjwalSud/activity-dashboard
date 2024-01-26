namespace activity_dashboard.Server.Architecture.Responses
{
    public class ReturnResponse
    {
        public int StatusCode { get; set; }
        public bool isSuccessful { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
