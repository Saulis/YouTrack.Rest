using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest.Tests.Interception
{
    class LoadableProxyInterceptorTests : TestFor<LoadableProxyInterceptor>
    {
        private IInvocation invocationWithoutLoadableTarget;
        private IInvocation invocationWithLoadableTarget;
        private ILoadable loadableTarget;

        protected override void SetupDependencies()
        {
            loadableTarget = Mock<ILoadable>();
            invocationWithoutLoadableTarget = Mock<IInvocation>();
            invocationWithLoadableTarget = CreateInvocationWithLoadableTarget();
        }

        private IInvocation CreateInvocationWithLoadableTarget()
        {
            IInvocation invocation = Mock<IInvocation>();
            invocation.InvocationTarget.Returns(loadableTarget);

            return invocation;
        }

        [Test]
        public void ExceptionIsThrownWhenInterceptingWithoutLoadable()
        {
            Assert.Throws<InterceptionTypeNotLoadableException>(() => Sut.Intercept(invocationWithoutLoadableTarget));
        }

        [Test]
        public void LoadIsCalledOnUnloaded()
        {
            loadableTarget.IsLoaded.Returns(false);

            Sut.Intercept(invocationWithLoadableTarget);

            loadableTarget.Received().Load();
        }

        [Test]
        public void LoadIsNotCalledForLoaded()
        {
            loadableTarget.IsLoaded.Returns(true);

            Sut.Intercept(invocationWithLoadableTarget);

            loadableTarget.DidNotReceive().Load();
        }
    }
}
