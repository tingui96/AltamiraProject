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
        public RegisterBadRequestException(string message) : base()
        {
            CustomCode = 400002;
            CustomMessage = message;
        }
    }
    public class UserExistBadRequestException : RegisterBadRequestException
    {
        public UserExistBadRequestException() : base("Username already in use")
        {
        }
    }
    public class EmailExistBadRequestException : RegisterBadRequestException
    {
        public EmailExistBadRequestException() : base("Email already in use")
        {
        }
    }
    public class EmailExpectedBadRequestException : RegisterBadRequestException
    {
        public EmailExpectedBadRequestException() : base("Email format incorrect")
        {
        }
    }
    public class PasswordUpperBadRequestException : RegisterBadRequestException
    {
        public PasswordUpperBadRequestException() : base("Password debe tener al menos 1 mayuscula")
        {
        }
    }
    public class PasswordLowerBadRequestException : RegisterBadRequestException
    {
        public PasswordLowerBadRequestException() : base("Password debe tener al menos 1 minuscula")
        {
        }
    }
    public class PasswordNumberBadRequestException : RegisterBadRequestException
    {
        public PasswordNumberBadRequestException() : base("Password debe tener al menos 1 numero")
        {
        }
    }
    public class PasswordLengthBadRequestException : RegisterBadRequestException
    {
        public PasswordLengthBadRequestException() : base("Password debe tener al menos 8 caracteres")
        {
        }
    }
    public class PasswordCharacterBadRequestException : RegisterBadRequestException
    {
        public PasswordCharacterBadRequestException() : base("Password debe tener al menos 1 caracter especial")
        {
        }
    }
    public class PasswordConfirmBadRequestException : RegisterBadRequestException
    {
        public PasswordConfirmBadRequestException() : base("Password different Confirm password")
        {
        }
    }
}
