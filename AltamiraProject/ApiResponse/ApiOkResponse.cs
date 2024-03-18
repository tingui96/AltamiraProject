namespace AltamiraProject.ApiResponse
{
    public class ApiOkResponse : BasicResponse
    {
        public object result { get; set; }
        public ApiOkResponse(object result) : base (200)
        {
            this.result = result;
        }
        public ApiOkResponse() : base(204)
        {
            this.result = "No Content";
        }
    }
}
