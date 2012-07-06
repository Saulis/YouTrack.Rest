namespace YouTrack.Rest.Requests
{
    public interface IYouTrackGetRequest : IYouTrackRequest
    {
    }

    public interface IYouTrackGetRequest<out TResponse> : IYouTrackGetRequest
    {
        TResponse Execute();
    }
}