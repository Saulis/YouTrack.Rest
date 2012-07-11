namespace YouTrack.Rest.Requests.Issues
{
    class AddCommentToIssueRequest : ApplyCommandToAnIssueRequest
    {
        public AddCommentToIssueRequest(string issueId, string comment) : base(issueId, comment: comment)
        {
        }
    }
}
