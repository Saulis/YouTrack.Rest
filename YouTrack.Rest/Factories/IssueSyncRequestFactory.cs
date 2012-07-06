using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Factories
{
    class IssueSyncRequestFactory : IIssueRequestFactory
    {
        public IYouTrackGetRequest<IIssue> GetIssueRequest(IIssue issue, IConnection connection)
        {
            return new GetIssueSyncRequest(issue, connection);
        }
    }
}