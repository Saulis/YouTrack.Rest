using System;

namespace YouTrack.Rest.Requests
{
    class CheckIfIssueExistsRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public CheckIfIssueExistsRequest(string issueId) : base(String.Format("/rest/issue/{0}/exists", issueId))
        {
        }
    }
}
