using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;
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
        private Rest.Deserialization.Issue deSerializedIssueMock;
        private IIssue issue;
        private CommentsCollection commentsCollection;
        private IIssueFactory issueFactory;

        protected override IssueRepository CreateSut()
        {
            connection = Mock<IConnection>();
            issue = Mock<IIssue>();
            deSerializedIssueMock = new DeserializedIssueMock(issue);
            commentsCollection = CreateCommentsWrapper();
            issueFactory = Mock<IIssueFactory>();

            return new IssueRepository(connection, issueFactory);
        }

        private static CommentsCollection CreateCommentsWrapper()
        {
            CommentsCollection commentsCollection = new CommentsCollection();
            commentsCollection.Comments = new List<Rest.Deserialization.Comment>();

            return commentsCollection;
        }

        [Test]
        public void IssueIsCreated()
        {
            connection.Put(Arg.Any<IYouTrackPutRequest>()).Returns("foobar");

            Sut.CreateIssue(Project, Summary, Description);

            issueFactory.Received().CreateIssue("foobar", connection);
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
        public void FactoryIsCalledOnGetIssue()
        {
            Sut.GetIssue(IssueId);

            issueFactory.Received().CreateIssue(IssueId, connection);
        }

        [Test]
        public void ConnectionIsCalledOnIssueExists()
        {
            Sut.IssueExists(IssueId);

            connection.Received().Get(Arg.Any<CheckIfIssueExistsRequest>());
        }

        [Test]
        public void IssueExists()
        {
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
    }
}
