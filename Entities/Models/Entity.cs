using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public Guid GetId()
        {
            return Id;
        }
    }
}
