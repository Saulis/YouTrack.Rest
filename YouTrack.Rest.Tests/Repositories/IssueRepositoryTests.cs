using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
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
        private IssueWrapper issueWrapper;
        private IIssue issue;
        private CommentsWrapper commentsWrapper;

        protected override IssueRepository CreateSut()
        {
            connection = Mock<IConnection>();
            issue = Mock<IIssue>();
            issueWrapper = new IssueWrapperMock(issue);
            commentsWrapper = CreateCommentsWrapper();

            return new IssueRepository(connection);
        }

        private static CommentsWrapper CreateCommentsWrapper()
        {
            CommentsWrapper commentsWrapper = new CommentsWrapper();
            commentsWrapper.Comments = new List<Comment>();

            return commentsWrapper;
        }

        [Test]
        public void IssueIdIsReturned()
        {
            connection.Put(Arg.Any<IYouTrackPutRequest>()).Returns("foobar");

            string issueId = Sut.CreateIssue(Project, Summary, Description);

            Assert.That(issueId, Is.EqualTo("foobar"));
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

            connection.Received().Get<IssueWrapper>(Arg.Any<GetIssueRequest>());
        }

        private void MockConnectionToReturnIssueDeserializerMockOnGetIssue()
        {
            connection.Get<IssueWrapper>(Arg.Any<GetIssueRequest>()).Returns(issueWrapper);
        }

        [Test]
        public void IssueIsReturnedOnGetIssue()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Assert.That(Sut.GetIssue(IssueId), Is.SameAs(issue));
        }

        [Test]
        public void ConnectionIsCalledOnAddComment()
        {
            Sut.AddComment(IssueId, "foobar");

            connection.Received().Post(Arg.Any<AddCommentToIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledOnCreateAndGetIssue()
        {
            MockConnectionToReturnIssueDeserializerMockOnGetIssue();

            Sut.CreateAndGetIssue(Project, Summary, Description);

            connection.Received().Put(Arg.Any<CreateNewIssueRequest>());
            connection.Received().Get<IssueWrapper>(Arg.Any<GetIssueRequest>());
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
        public void ConnectionIsCalledOnGetComments()
        {
            connection.Get<CommentsWrapper>(Arg.Any<GetCommentsOfAnIssueRequest>()).Returns(commentsWrapper);

            Sut.GetComments(IssueId);

            connection.Received().Get<CommentsWrapper>(Arg.Any<GetCommentsOfAnIssueRequest>());
        }
    }
}
