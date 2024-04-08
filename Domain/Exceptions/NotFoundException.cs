using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : Exception, IServiceException
    {
        public NotFoundException(string message)
        {
            Message = message;
        }
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public string Message { get; }
    }
}
