using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Role : Entity
    { 
        public string Name { get; set;}
        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set;}
        public User? User { get; set;}
    }
}
