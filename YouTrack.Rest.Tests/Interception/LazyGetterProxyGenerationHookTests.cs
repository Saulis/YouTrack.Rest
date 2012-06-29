using NUnit.Framework;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest.Tests.Interception
{
    class LazyGetterProxyGenerationHookTests : TestFor<LazyGetterProxyGenerationHook>
    {
        [Test]
        public void GetterShouldBeInspected()
        {
            Assert.IsTrue(Sut.ShouldInterceptMethod(typeof(TestType), typeof(TestType).GetMethod("get_Property")));
        }

        [Test]
        public void IdGetterShouldNotBeInspectedForLoadable()
        {
            Assert.IsFalse(Sut.ShouldInterceptMethod(typeof(ILoadable), typeof(LoadableTestType).GetMethod("get_Id")));
        }

        [Test]
        public void IdGetterShouldBeInspectedForUnloadable()
        {
            Assert.IsTrue(Sut.ShouldInterceptMethod(typeof(TestType), typeof(TestType).GetMethod("get_Id")));
        }

        [Test]
        public void SetterShouldNotBeInspected()
        {
            Assert.IsFalse(Sut.ShouldInterceptMethod(typeof(TestType), typeof(TestType).GetMethod("set_Property")));
        }

        [Test]
        public void MethodShouldNotBeInspected()
        {
            Assert.IsFalse(Sut.ShouldInterceptMethod(typeof(TestType), typeof(TestType).GetMethod("Method")));
        }

        private class LoadableTestType : ILoadable
        {
            public string Id
            {
                get { throw new System.NotImplementedException(); }
            }

            public bool IsLoaded
            {
                get { throw new System.NotImplementedException(); }
            }

            public void Load()
            {
                throw new System.NotImplementedException();
            }
        }

        private class TestType
        {
            public string Id { get; set; }

            public string Property { get; set; }
            
            public void Method()
            {
                
            }
        }
    }
}
