namespace YouTrack.Rest.Factories
{
    class IssueProxyFactory : ProxyFactory, IIssueFactory
    {
        public IIssue CreateIssue(string issueId, IConnection connection, IIssueRequestFactory issueRequestFactory)
        {
            LoadableIssue issue = new LoadableIssue(issueId, connection, issueRequestFactory);

            return CreateProxy<IIssue>(issue);
        }
    }
}
