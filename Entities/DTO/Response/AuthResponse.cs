using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Response
{
    public class AuthResponse
    {
        public string? Token { get; }
        public UserResponse User { get; set; }
        public string? Role { get; set; }
       
        public AuthResponse(string token, UserResponse userResponse, string role)
        {
            Token = token;
            User = userResponse;
            Role = role;
        }
    }
}
