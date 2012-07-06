using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Factories
{
    public interface IIssueRequestFactory
    {
        IYouTrackGetRequest<IIssue> GetIssueRequest(IIssue issue, IConnection connection);
    }
}
