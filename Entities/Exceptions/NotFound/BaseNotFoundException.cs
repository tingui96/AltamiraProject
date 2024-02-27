using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.NotFound
{
    public class BaseNotFoundException : BaseException
    {
        public BaseNotFoundException() : base()
        {
            HttpCode = (int)HttpStatusCode.NotFound;
        }
    }
}
