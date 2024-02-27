namespace AltamiraProject.ApiResponse
{
    public abstract class BasicResponse
    {
        public int StatusCode { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }
        public BasicResponse(int statusCode, object result, string message)
        {
            StatusCode = statusCode;
            Result = result;
            Message = message;
        }
    }
}
