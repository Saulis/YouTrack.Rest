using Castle.DynamicProxy;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Interception
{
    class LoadableProxyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            ILoadable target = invocation.InvocationTarget as ILoadable;

            ThrowIfTargetNotLoadable(target);

            if(!target.IsLoaded)
            {
                target.Load();
            }

            invocation.Proceed();
        }

        private void ThrowIfTargetNotLoadable(ILoadable target)
        {
            if(target == null)
            {
                throw new InterceptionTypeNotLoadableException();
            }
        }
    }
}