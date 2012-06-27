using System;

namespace YouTrack.Rest.Requests
{
    class RemoveACommentForAnIssueRequest : YouTrackRequest, IYouTrackDeleteRequest
    {
        public RemoveACommentForAnIssueRequest(string issueId, string commentId) : base(String.Format("/rest/issue/{0}/comment/{1}", issueId, commentId))
        {
        }
    }
}