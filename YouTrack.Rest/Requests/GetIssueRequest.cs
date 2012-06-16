using System;

namespace YouTrack.Rest.Requests
{
    class GetIssueRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetIssueRequest(string issueId)
            : base(String.Format("/rest/issue/{0}", issueId))
        {
        }
    }
}