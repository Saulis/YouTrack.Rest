using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    public interface IYouTrackClient
    {
        IConnection GetConnection();
        IIssueRepository GetIssueRepository();
        string Put(IYouTrackPutRequest request);
        TResponse Get<TResponse>(IYouTrackGetRequest request) where TResponse : new();
    }
}