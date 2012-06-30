using NUnit.Framework;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest.Tests.Interception
{
    class PropertyGetterProxyGenerationHookTests : TestFor<PropertyGetterProxyGenerationHook<TestType>>
    {
        protected override PropertyGetterProxyGenerationHook<TestType> CreateSut()
        {
            return new PropertyGetterProxyGenerationHook<TestType>();
        }

        [Test]
        public void GetterShouldBeInspected()
        {
            Assert.IsTrue(Sut.ShouldInterceptMethod(typeof(TestType), typeof(TestType).GetMethod("get_Property")));
        }

        [Test]
        public void GetterInNonProxiedTypeShouldNotBeInspected()
        {
            Assert.IsFalse(Sut.ShouldInterceptMethod(typeof(AnotherTestType), typeof(AnotherTestType).GetMethod("get_Property")));
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
    }

    public class TestType
    {
        public string Id { get; set; }

        public string Property { get; set; }

        public void Method()
        {

        }
    }

    public class AnotherTestType
    {
        public string Property { get; set; }
    }
}
