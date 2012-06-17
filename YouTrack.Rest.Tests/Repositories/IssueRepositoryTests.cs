using System;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Repositories
{

    internal class IssueRepositoryTests : TestFor<IssueRepository>
    {
        private const string Project = "project";
        private const string Summary = "summary";
        private const string Description = "description";
        private const string IssueId = "FOO-BAR";
        private IConnection connection;
        private IssueDeserializer issueDeserializer;
        private IIssue issue;

        protected override IssueRepository CreateSut()
        {
            connection = Mock<IConnection>();
            issue = Mock<IIssue>();
            issueDeserializer = new IssueDeserializerMock(issue);

            return new IssueRepository(connection);
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

            connection.Received().Get<IssueDeserializer>(Arg.Any<GetIssueRequest>());
        }

        private void MockConnectionToReturnIssueDeserializerMockOnGetIssue()
        {
            connection.Get<IssueDeserializer>(Arg.Any<GetIssueRequest>()).Returns(issueDeserializer);
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
            connection.Received().Get<IssueDeserializer>(Arg.Any<GetIssueRequest>());
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
    }
}
