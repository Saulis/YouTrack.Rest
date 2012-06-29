using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Tests.Repositories;

namespace YouTrack.Rest.Tests
{
    class IssueTests : TestFor<Issue>
    {
        private IConnection connection;

        protected override Issue CreateSut()
        {
            connection = Mock<IConnection>();
            return new Issue("FOO-BAR", connection);
        }

        protected override void SetupDependencies()
        {
            connection.Get<Rest.Deserialization.Issue>(Arg.Any<GetIssueRequest>()).Returns(new DeserializedIssueMock());
        }

        [Test]
        public void IsNotLoadedWhenConstructed()
        {
            Assert.IsFalse(((ILoadable)Sut).IsLoaded);
        }

        [Test]
        public void LoadSetLoaded()
        {
            ILoadable loadable = Sut;

            loadable.Load();

            Assert.IsTrue(loadable.IsLoaded);
        }
    }
}
