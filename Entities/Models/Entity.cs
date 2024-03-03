namespace Entities.Models
{
    public class Entity 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool Deleted { get; set; }

    }
}
