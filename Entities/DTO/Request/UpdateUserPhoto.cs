using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class UpdateUserPhoto
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
    }
}
