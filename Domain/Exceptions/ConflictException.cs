using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ConflictException : Exception, IServiceException
    {
        public ConflictException(string message)
        {
            Message = message;
        }
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
        public string Message { get; }
    }
}
