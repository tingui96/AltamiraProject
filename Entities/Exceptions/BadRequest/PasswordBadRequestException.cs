using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.BadRequest
{
    public class PasswordBadRequestException : BaseBadRequestException
    {
        public PasswordBadRequestException() : base()
        {
            CustomCode = 400001;
            CustomMessage = "Wrong password";
        }
    }
}
