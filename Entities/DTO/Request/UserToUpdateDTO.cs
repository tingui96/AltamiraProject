namespace Entities.DTO.Request
{
    public class UserToUpdateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Biography { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
