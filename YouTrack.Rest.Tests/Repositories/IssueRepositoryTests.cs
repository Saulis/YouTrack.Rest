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
        private IIssue issue;

        protected override IssueRepository CreateSut()
        {
            connection = Mock<IConnection>();
            issue = new Issue();

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
        public void ClientIsCalledOnCreateIssue()
        {
            Sut.CreateIssue(Project, Summary, Description);

            connection.Received().Put(Arg.Any<CreateNewIssueRequest>());
        }

        [Test]
        public void ClientIsCalledOnDeleteIssue()
        {
            Sut.DeleteIssue(IssueId);

            connection.Received().Delete(Arg.Any<DeleteIssueRequest>());
        }

        [Test]
        public void ClientIsCalledOnGetIssue()
        {
            Sut.GetIssue(IssueId);

            connection.Get<Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void IssueIsReturnedOnGetIssue()
        {
            connection.Get<Issue>(Arg.Any<GetIssueRequest>()).Returns(issue);

            Assert.That(Sut.GetIssue(IssueId), Is.SameAs(issue));
        }

        [Test]
        public void ClientIsCalledOnCreateAndGetIssue()
        {
            Sut.CreateAndGetIssue(Project, Summary, Description);

            connection.Received().Put(Arg.Any<CreateNewIssueRequest>());
            connection.Received().Get<Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void ClientIsCalledOnIssueExists()
        {
            Sut.IssueExists(IssueId);

            connection.Received().Get<Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void IssueExists()
        {
            connection.Get<Issue>(Arg.Any<GetIssueRequest>()).Returns(issue);

            Assert.IsTrue(Sut.IssueExists(IssueId));
        }

        [Test]
        public void IssueDoesNotExist()
        {
            connection.When(x => x.Get<Issue>(Arg.Any<GetIssueRequest>())).Do(x =>
                                                                                      {
                                                                                          throw new RequestNotFoundException(Mock<IRestResponse>());
                                                                                      });

            Assert.IsFalse(Sut.IssueExists(IssueId));
        }
    }
}
