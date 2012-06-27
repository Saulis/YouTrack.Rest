using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Tests.Requests;

namespace YouTrack.Rest.Tests.Repositories
{

    internal class IssueRepositoryTests : TestFor<IssueRepository>
    {
        private const string Project = "project";
        private const string Summary = "summary";
        private const string Description = "description";
        private const string IssueId = "FOO-BAR";
        private IConnection connection;
        private Rest.Deserialization.Issue issueDeserializer;
        private IIssue issue;
        private CommentsCollection commentsCollection;

        protected override IssueRepository CreateSut()
        {
            connection = Mock<IConnection>();
            issue = Mock<IIssue>();
            issueDeserializer = new IssueMock(issue);
            commentsCollection = CreateCommentsWrapper();

            return new IssueRepository(connection);
        }

        private static CommentsCollection CreateCommentsWrapper()
        {
            CommentsCollection commentsCollection = new CommentsCollection();
            commentsCollection.Comments = new List<Rest.Deserialization.Comment>();

            return commentsCollection;
        }

        [Test]
        public void IssueIdIsReturned()
        {
            connection.Put(Arg.Any<IYouTrackPutRequest>()).Returns("foobar");

            IIssueProxy issueProxy = Sut.CreateIssue(Project, Summary, Description);

            Assert.That(issueProxy.Id, Is.EqualTo("foobar"));
        }

        [Test]
        public void ConnectionIsCalledOnCreateIssue()
        {
            Sut.CreateIssue(Project, Summary, Description);

            connection.Received().Put(Arg.Any<CreateNewIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledOnDeleteIssue()
        {
            Sut.DeleteIssue(IssueId);

            connection.Received().Delete(Arg.Any<DeleteIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledOnGetIssue()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Sut.GetIssue(IssueId);

            connection.Received().Get<Rest.Deserialization.Issue>(Arg.Any<GetIssueRequest>());
        }

        private void MockConnectionToReturnIssueDeserializerMockOnGetIssue()
        {
            connection.Get<Rest.Deserialization.Issue>(Arg.Any<GetIssueRequest>()).Returns(issueDeserializer);
        }

        [Test]
        public void IssueIsReturnedOnGetIssue()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Assert.That(Sut.GetIssue(IssueId), Is.SameAs(issue));
        }

        
        [Test]
        public void ConnectionIsCalledOnCreateAndGetIssue()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Sut.CreateAndGetIssue(Project, Summary, Description);

            connection.Received().Put(Arg.Any<CreateNewIssueRequest>());
            connection.Received().Get<Rest.Deserialization.Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledOnIssueExists()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Sut.IssueExists(IssueId);

            connection.Received().Get(Arg.Any<CheckIfIssueExistsRequest>());
        }

        [Test]
        public void IssueExists()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Assert.IsTrue(Sut.IssueExists(IssueId));
        }

        [Test]
        public void IssueDoesNotExist()
        {
            connection.When(x => x.Get(Arg.Any<CheckIfIssueExistsRequest>())).Do(x =>
                                                                                      {
                                                                                          throw new RequestNotFoundException(Mock<IRestResponse>());
                                                                                      });

            Assert.IsFalse(Sut.IssueExists(IssueId));
        }


        [Test]
        public void ReturnsIssueProxy()
        {
            Assert.That(Sut.GetIssueProxy(IssueId), Is.TypeOf<Issue>());
        }

        [Test]
        public void IdIsSetToProxy()
        {
            Assert.That(Sut.GetIssueProxy(IssueId).Id, Is.EqualTo(IssueId));
        }
    }
}
