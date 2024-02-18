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
       
        public AuthResponse(string token)
        {
            Token = token;
        }
    }
}
