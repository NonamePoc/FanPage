using System.Net;
using System.Runtime.Serialization;


namespace FanPage.Exceptions
{
    [Serializable]
    public class FanficException : ClientExceptionBase
    {
        public FanficException()
        {
        }

        public FanficException(string message) : base(message)
        {
        }

        public FanficException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FanficException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}