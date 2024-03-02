using System.ComponentModel.DataAnnotations;

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
