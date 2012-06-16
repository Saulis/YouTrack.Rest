using System;
using NSubstitute;
using NUnit.Framework;

namespace YouTrack.Rest.Tests
{
    [TestFixture]
    public abstract class TestFor<TSut>
    {
        public TSut Sut { get; private set; }

        [SetUp]
        public void Setup()
        {
            Sut = CreateSut();

            SetupDependencies();
        }

        protected virtual void SetupDependencies()
        {
            
        }

        protected virtual TSut CreateSut()
        {
            return Activator.CreateInstance<TSut>();
        }

        protected TMock Mock<TMock>(params object[] constructorArguments) where TMock : class
        {
            return Substitute.For<TMock>(constructorArguments);
        }
    }
}
