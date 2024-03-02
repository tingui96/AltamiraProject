namespace Entities.Exceptions
{
    public class BaseException : Exception
    {
        public int HttpCode { get; set; }
        public int CustomCode { get; set; }
        public string CustomMessage { get; set; }
        public BaseException() : base() { }

        public BaseException(string message) : base(message) { }
  
    }
}
