using System;
using System.Net;
using System.Runtime.Serialization;


namespace FanPage.Exceptions
{
    [Serializable]
    public class UserCreateException : ClientExceptionBase
    {
        public UserCreateException()
        {
        }


        public UserCreateException(string message) : base(message)
        {
        }

        public UserCreateException(string message, Exception inner) : base(message, inner)
        {
        }

        protected UserCreateException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    }
}