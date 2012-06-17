namespace YouTrack.Rest.Requests
{
    class AddCommentToIssueRequest : ApplyCommandToAnIssueRequest
    {
        public AddCommentToIssueRequest(string issueId, string comment) : base(issueId, comment: comment)
        {
        }
    }
}
