using System;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class GetIssueAsyncRequestTests : GetIssueRequestTests<GetIssueAsyncRequest>
    {
        protected override GetIssueAsyncRequest CreateSut()
        {
            Connection = Mock<IConnection>();
            Issue = new Issue("FOO-123", Connection, Mock<IIssueRequestFactory>());

            return new GetIssueAsyncRequest(Issue, Connection);
        }

        protected override void SetupDependencies()
        {
            DeserializedIssue = Mock<Rest.Deserialization.Issue>();

            Connection.When(
                x => x.GetAsync(Arg.Any<IYouTrackGetRequest>(), Arg.Any<Action<Rest.Deserialization.Issue>>())).Do(
                    x => x.Arg<Action<Rest.Deserialization.Issue>>().Invoke(DeserializedIssue));
        }

        [Test]
        public void RequestIsAsync()
        {
            Sut.Execute();

            Connection.Received().GetAsync(Arg.Any<IYouTrackGetRequest>(), Arg.Any<Action<Rest.Deserialization.Issue>>());
        }

        [Test]
        public void RequestIsPassed()
        {
            Sut.Execute();

            Connection.Received().GetAsync(Arg.Is(Sut), Arg.Any<Action<Rest.Deserialization.Issue>>());
        }
    }
}
