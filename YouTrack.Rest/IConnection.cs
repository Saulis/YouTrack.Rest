using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    public interface IConnection
    {
        string Put(IYouTrackPutRequest request);
        TResponse Get<TResponse>(IYouTrackGetRequest request) where TResponse : new();
        void Get(IYouTrackGetRequest request);
        void Delete(IYouTrackDeleteRequest request);
        void Post(IYouTrackPostRequest request);
    }
}