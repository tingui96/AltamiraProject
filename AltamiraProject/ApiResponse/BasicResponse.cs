namespace AltamiraProject.ApiResponse
{
    public abstract class BasicResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public BasicResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
