using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Request
{
    public class ObraModel
    {
        [Required, StringLength(50)]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public TypeEnum Tipo { get; set; }
        [Required]
        public string Descripcion { get; set; } = string.Empty;
    }
}
