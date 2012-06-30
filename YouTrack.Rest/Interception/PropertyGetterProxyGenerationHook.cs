using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace YouTrack.Rest.Interception
{
    class PropertyGetterProxyGenerationHook<TProxy> : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            bool shouldInterceptMethod = type == typeof (TProxy) && methodInfo.Name.StartsWith("get_", StringComparison.Ordinal);

            return shouldInterceptMethod;
        }
    }
}
