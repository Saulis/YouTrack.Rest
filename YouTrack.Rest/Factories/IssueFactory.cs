namespace YouTrack.Rest.Factories
{
    class IssueFactory : ProxyFactory, IIssueFactory
    {
        public IIssue CreateIssue(string issueId, IConnection connection)
        {
            Issue issue = new Issue(issueId, connection);

            return CreateProxy<IIssue>(issue);
        }
    }
}
