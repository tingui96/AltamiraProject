using Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Obra : Entity
    {
        [Required, StringLength(50)]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public TypeEnum Tipo { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string PhotoUrl { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
