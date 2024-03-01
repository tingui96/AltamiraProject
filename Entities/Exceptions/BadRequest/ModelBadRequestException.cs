using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.BadRequest
{
    public class ModelBadRequestException : BaseBadRequestException
    {
        public ModelBadRequestException(IEnumerable<string> errors) : base()
        {
            CustomCode = 400003;
            CustomMessage = errors.First();
        }
    }
}
