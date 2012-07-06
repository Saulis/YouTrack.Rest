using System;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Factories
{
    class IssueAsyncRequestFactory : IIssueRequestFactory
    {
        public IYouTrackGetRequest<IIssue> GetIssueRequest(IIssue issue, IConnection connection)
        {
            return new GetIssueAsyncRequest(issue, connection);
        }
    }
}