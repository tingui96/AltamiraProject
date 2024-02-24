using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Response
{
    public class UserWithDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Biography { get; set; }
        public string PhotoUrl { get; set; }
        public bool Activo { get; set; }
        public ICollection<RoleResponse> Roles { get; set; }
    }
}
