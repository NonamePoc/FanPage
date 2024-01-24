using System.Net;
using System.Runtime.Serialization;

namespace FanPage.Exceptions;

[Serializable]
public class ChatException : ClientExceptionBase
{
    public ChatException()
    {
    }

    public ChatException(string message) : base(message)
    {
    }

    public ChatException(string message, Exception inner) : base(message, inner)
    {
    }

    protected ChatException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
}