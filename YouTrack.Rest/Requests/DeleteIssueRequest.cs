using System;

namespace YouTrack.Rest.Requests
{
    class DeleteIssueRequest : YouTrackRequest, IYouTrackDeleteRequest
    {
        public DeleteIssueRequest(string issueId) : base(String.Format("/rest/issue/{0}", issueId))
        {
        }
    }
}
