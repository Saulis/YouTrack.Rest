using Castle.DynamicProxy;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest.Factories
{
    class IssueFactory : IIssueFactory
    {
        public IIssue CreateIssue(string issueId, IConnection connection)
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();

            Issue issue = new Issue(issueId, connection);
            ProxyGenerationOptions proxyGenerationOptions = new ProxyGenerationOptions(new PropertyGetterProxyGenerationHook<Issue>(x => x.Id));

            object issueProxy = proxyGenerator.CreateInterfaceProxyWithTargetInterface(typeof (IIssue), issue, proxyGenerationOptions, new LoadableProxyInterceptor());

            return (IIssue)issueProxy;
        }
    }
}
