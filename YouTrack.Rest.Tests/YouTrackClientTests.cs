using System;
using NUnit.Framework;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Tests
{
    [TestFixture]
    class YouTrackClientTests : TestFor<YouTrackClient>
    {
        protected override YouTrackClient CreateSut()
        {
            return new YouTrackClient("http://foo.bar", "login", "password");
        }

        [Test]
        public void IssueRepositoryIsReturned()
        {
            Assert.That(Sut.GetIssueRepository(), Is.TypeOf<IssueRepository>());
        }

        [Test]
        public void ConnectionIsReturned()
        {
            Assert.That(Sut.GetConnection(), Is.TypeOf<Connection>());
        }
    }
}