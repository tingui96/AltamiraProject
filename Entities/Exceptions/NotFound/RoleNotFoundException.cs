using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.NotFound
{
    public class RoleNotFoundException: BaseNotFoundException
    {
        public RoleNotFoundException() : base()
        {
            CustomCode = 404003;
            CustomMessage = "Role not Found";
        }
    }
}
