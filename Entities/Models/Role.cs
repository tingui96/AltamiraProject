namespace Entities.Models
{
    public class Role : Entity
    { 
        public string Name { get; set;}
        public IEnumerable<User> Users { get; set;} = new List<User>();
    }
}
