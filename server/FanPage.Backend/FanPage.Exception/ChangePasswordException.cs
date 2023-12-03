using System.Net;
using System.Runtime.Serialization;

namespace FanPage.Exceptions
{
    [Serializable]
    public class ChangePasswordException : ClientExceptionBase
    {
        public ChangePasswordException()
        {
        }

        public ChangePasswordException(string message) : base(message)
        {
        }

        public ChangePasswordException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ChangePasswordException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}