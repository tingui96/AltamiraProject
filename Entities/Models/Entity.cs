namespace Entities.Models
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public Guid GetId()
        {
            return Id;
        }
    }
}
