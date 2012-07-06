using System;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    abstract class GetIssueRequestTests<TRequest> : YouTrackRequestTests<TRequest, IYouTrackGetRequest> where TRequest : GetIssueRequest
    {
        protected override string ExpectedRestResource
        {
            get { return String.Format("/rest/issue/{0}", Issue.Id); }
        }

        protected IConnection Connection { get; set; }
        protected IIssue Issue { get; set; }
        protected Rest.Deserialization.Issue DeserializedIssue { get; set; }

        [Test]
        public void IssueIsMapped()
        {
            Sut.Execute();

            DeserializedIssue.Received().MapTo(Issue, Connection);
        }

        [Test]
        public void EventRaisedAfterExecution()
        {
            Sut.Executed += (sender, args) => Assert.Pass();

            Sut.Execute();

            Assert.Fail();
        }
    }
}
