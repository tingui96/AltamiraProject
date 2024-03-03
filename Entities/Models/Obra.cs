using Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Obra : Entity
    {
        [Required, StringLength(50)]
        public string Titulo { get; set; }
        [Required]
        public TypeEnum Tipo { get; set; }
        public string Descripcion { get; set; }
        public string PhotoUrl { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
