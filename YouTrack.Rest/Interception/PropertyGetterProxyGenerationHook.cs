using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Castle.DynamicProxy;

namespace YouTrack.Rest.Interception
{
    class PropertyGetterProxyGenerationHook<TProxy> : IProxyGenerationHook
    {
        private readonly ICollection<string> excludedPropertyGetters;

        public PropertyGetterProxyGenerationHook(params Expression<Func<TProxy, object>>[] excludedProperties)
        {
            excludedPropertyGetters = GetExcludedPropertyGetters(excludedProperties);
        }

        private ICollection<string> GetExcludedPropertyGetters(IEnumerable<Expression<Func<TProxy, object>>> excludedProperties)
        {
            if(excludedProperties == null)
            {
                return new Collection<string>();
            }

            IEnumerable<MemberExpression> propertyGetterBodies = excludedProperties.Select(p => (MemberExpression)p.Body);
            IEnumerable<string> propertyGetterNames = propertyGetterBodies.Select(b => "get_" + b.Member.Name);

            return propertyGetterNames.ToList();
        }

        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            if (IsExcluded(methodInfo))
            {
                return false;
            }

            return methodInfo.Name.StartsWith("get_", StringComparison.Ordinal);
        }

        private bool IsExcluded(MethodInfo methodInfo)
        {
            if (!excludedPropertyGetters.Any())
            {
                return false;
            }

            return excludedPropertyGetters.Contains(methodInfo.Name);
        }
    }
}
