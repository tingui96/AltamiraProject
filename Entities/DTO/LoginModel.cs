using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class LoginModel
    {
        [Required]
        public string Usuario { get; }
        [Required, StringLength(20) ,MinLength(8)]
        public string Password { get; }

        public LoginModel(string usuario, string password)
        {
            Usuario = usuario;
            Password = password;
        }
    }
}
