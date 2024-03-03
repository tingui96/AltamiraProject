using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class User :  Entity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string? Phone {  get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Biography { get; set; }
        public ICollection<Obra> Obras { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
