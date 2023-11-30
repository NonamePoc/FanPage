namespace FanPage.Api.JsonResponse
{
    public class JsonResponseContainer<T>
    {
        public T Data { get; set; }
        public IReadOnlyCollection<JsonResponseError> Errors { get; set; } = Array.Empty<JsonResponseError>();

        public bool Success => !Errors.Any();
    }

    public class JsonResponseContainer
    {
        public object Data { get; set; } = new object();
        public IReadOnlyCollection<JsonResponseError> Errors { get; set; } = Array.Empty<JsonResponseError>();

        public bool Success => !Errors.Any();
    }
}