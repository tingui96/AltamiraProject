using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.BadRequest
{
    public class RegisterBadRequestException : BaseBadRequestException
    {
        public RegisterBadRequestException(IEnumerable<IdentityError> errors) : base()
        {
            CustomCode = 400002;
            CustomMessage = errors.First().Description;
        }
    }
}
