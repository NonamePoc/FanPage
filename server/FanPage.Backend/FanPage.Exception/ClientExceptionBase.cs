using System;
using System.Net;
using System.Runtime.Serialization;

namespace FanPage.Exceptions
{
    [Serializable]
    public class ClientExceptionBase : Exception
    {
        protected ClientExceptionBase()
        {
        }

        protected ClientExceptionBase(string message) : base(message)
        {
        }

        protected ClientExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     default Exception
        /// </summary>
        public virtual HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    }
}