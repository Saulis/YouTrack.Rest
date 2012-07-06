namespace YouTrack.Rest.Factories
{
    class IssueFactory : IIssueFactory
    {
        public IIssue CreateIssue(string issueId, IConnection connection, IIssueRequestFactory issueRequestFactory)
        {
            return new Issue(issueId, connection, issueRequestFactory);
        }
    }
}