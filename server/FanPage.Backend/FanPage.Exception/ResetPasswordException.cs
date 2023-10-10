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
    public class ResetPasswordException : ClientExceptionBase
    {
        public ResetPasswordException()
        {
        }

        public ResetPasswordException(string message) : base(message)
        {
        }

        public ResetPasswordException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ResetPasswordException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
