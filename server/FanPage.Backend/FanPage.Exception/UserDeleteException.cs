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
    public class UserDeleteException : ClientExceptionBase
    {
        public UserDeleteException()
        {
        }

        public UserDeleteException(string message) : base(message)
        {
        }

        public UserDeleteException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UserDeleteException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
