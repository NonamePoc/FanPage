using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Exceptions
{
    [Serializable]
    public class LogInException : ClientExceptionBase
    {
        public LogInException()
        {
        }

        public LogInException(string message) : base(message)
        {
        }

        public LogInException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LogInException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}