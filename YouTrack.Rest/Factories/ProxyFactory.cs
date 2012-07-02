using Castle.DynamicProxy;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest.Factories
{
    abstract class ProxyFactory
    {
        public TProxy CreateProxy<TProxy>(object target)
        {
            ProxyGenerator proxyGenerator = new ProxyGenerator();

            ProxyGenerationOptions proxyGenerationOptions = new ProxyGenerationOptions(new PropertyGetterProxyGenerationHook<TProxy>());

            object issueProxy = proxyGenerator.CreateInterfaceProxyWithTargetInterface(typeof(TProxy), target, proxyGenerationOptions, new LoadableProxyInterceptor());

            return (TProxy)issueProxy;
        }
    }
}