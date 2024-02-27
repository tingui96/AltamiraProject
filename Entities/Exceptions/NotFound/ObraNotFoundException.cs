using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.NotFound
{
    public class ObraNotFoundException : BaseNotFoundException
    {
        public ObraNotFoundException() : base()
        {
            CustomCode = 404002;
            CustomMessage = "Obra not Found";
        }
    }
}
