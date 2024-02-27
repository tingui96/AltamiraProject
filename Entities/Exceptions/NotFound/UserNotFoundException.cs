using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
