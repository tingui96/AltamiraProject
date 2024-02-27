using Newtonsoft.Json;

namespace AltamiraProject.ApiResponse
{
    public class BasicResponse
    {
        public int StatusCode { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get;  }
        public int CustomStatusCode { get; }
        public BasicResponse(int statusCode, string message = null, int customStatusCode = 0)
        {
            StatusCode = statusCode;
            Message = message;
            CustomStatusCode = customStatusCode;
        }
    }
}
