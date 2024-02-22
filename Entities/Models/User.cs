using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User : IdentityUser, IEntity
    {
        public string Name { get; set; }
        public bool Activo { get; set; }

        public Guid GetId()
        {
            return Guid.Parse(Id);
        }
    }
}
