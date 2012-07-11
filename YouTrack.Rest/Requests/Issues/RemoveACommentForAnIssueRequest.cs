using System;

namespace YouTrack.Rest.Requests.Issues
{
    class RemoveACommentForAnIssueRequest : YouTrackRequest, IYouTrackDeleteRequest
    {
        public RemoveACommentForAnIssueRequest(string issueId, string commentId) : base(String.Format("/rest/issue/{0}/comment/{1}", issueId, commentId))
        {
        }
    }
}