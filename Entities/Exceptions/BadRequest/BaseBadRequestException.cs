using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.BadRequest
{
    public class BaseBadRequestException : BaseException
    {
        public BaseBadRequestException() : base()
        {
            HttpCode = (int)HttpStatusCode.BadRequest;
        }
    }
}
