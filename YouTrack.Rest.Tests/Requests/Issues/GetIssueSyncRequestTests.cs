using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class GetIssueSyncRequestTests : GetIssueRequestTests<GetIssueSyncRequest>
    {
        protected override GetIssueSyncRequest CreateSut()
        {
            Connection = Mock<IConnection>();
            Issue = new Issue("FOO-123", Connection, Mock<IIssueRequestFactory>());

            return new GetIssueSyncRequest(Issue, Connection);
        }

        protected override void SetupDependencies()
        {
            DeserializedIssue = Mock<Rest.Deserialization.Issue>();

            Connection.Get<Rest.Deserialization.Issue>(Sut).Returns(DeserializedIssue);
        }

        [Test]
        public void RequestIsSync()
        {
            Sut.Execute();

            Connection.Received().Get<Rest.Deserialization.Issue>(Sut);
        }

        [Test]
        public void RequestIsPassed()
        {
            Sut.Execute();

            Connection.Received().Get<Rest.Deserialization.Issue>(Sut);
        }
    }
}
