namespace YouTrack.Rest.Factories
{
    class IssueFactory : ProxyFactory, IIssueFactory
    {
        public IIssue CreateIssue(string issueId, IConnection connection, IIssueRequestFactory issueRequestFactory)
        {
            Issue issue = new Issue(issueId, connection, issueRequestFactory);

            return CreateProxy<IIssue>(issue);
        }
    }
}
