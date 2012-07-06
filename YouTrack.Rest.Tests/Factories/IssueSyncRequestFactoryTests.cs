using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Factories
{
    class IssueSyncRequestFactoryTests : TestFor<IssueSyncRequestFactory>
    {
        [Test]
        public void GetIssueSyncRequestCreated()
        {
            Assert.That(Sut.GetIssueRequest(Mock<IIssue>(), Mock<IConnection>()), Is.TypeOf<GetIssueSyncRequest>());
        }
    }
}
