namespace Entities.Exceptions.NotFound
{
    public class UserNotFoundException : BaseNotFoundException
    {
        public UserNotFoundException() : base()
        {
            CustomCode = 404001;
            CustomMessage = "User not Found";
        }
        
    }
}
