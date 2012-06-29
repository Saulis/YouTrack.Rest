using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace YouTrack.Rest.Interception
{
    class LazyGetterProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            if (IsLoadable(type))
            {
                return false;
            }

            return methodInfo.Name.StartsWith("get_", StringComparison.Ordinal);
        }

        private bool IsLoadable(Type type)
        {
            return type == typeof(ILoadable);
        }
    }
}
