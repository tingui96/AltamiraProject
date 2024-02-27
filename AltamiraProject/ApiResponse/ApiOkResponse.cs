namespace AltamiraProject.ApiResponse
{
    public class ApiOkResponse : BasicResponse
    {
        public ApiOkResponse(object result) : base (200,result,"Ok")
        {
        }
    }
}
