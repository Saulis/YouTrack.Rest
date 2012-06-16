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
        private IYouTrackClient youTrackClient;
        private IIssue issue;

        protected override IssueRepository CreateSut()
        {
            youTrackClient = Mock<IYouTrackClient>();
            issue = new Issue();

            return new IssueRepository(youTrackClient);
        }

        [Test]
        public void IssueIdIsReturned()
        {
            youTrackClient.Put(Arg.Any<IYouTrackPutRequest>()).Returns("foobar");

            string issueId = Sut.CreateIssue(Project, Summary, Description);

            Assert.That(issueId, Is.EqualTo("foobar"));
        }

        [Test]
        public void ClientIsCalledOnCreateIssue()
        {
            Sut.CreateIssue(Project, Summary, Description);

            youTrackClient.Received().Put(Arg.Any<CreateNewIssueRequest>());
        }

        [Test]
        public void ClientIsCalledOnDeleteIssue()
        {
            Sut.DeleteIssue(IssueId);

            youTrackClient.Received().Delete(Arg.Any<DeleteIssueRequest>());
        }

        [Test]
        public void ClientIsCalledOnGetIssue()
        {
            Sut.GetIssue(IssueId);

            youTrackClient.Get<Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void IssueIsReturnedOnGetIssue()
        {
            youTrackClient.Get<Issue>(Arg.Any<GetIssueRequest>()).Returns(issue);

            Assert.That(Sut.GetIssue(IssueId), Is.SameAs(issue));
        }

        [Test]
        public void ClientIsCalledOnCreateAndGetIssue()
        {
            Sut.CreateAndGetIssue(Project, Summary, Description);

            youTrackClient.Received().Put(Arg.Any<CreateNewIssueRequest>());
            youTrackClient.Received().Get<Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void ClientIsCalledOnIssueExists()
        {
            Sut.IssueExists(IssueId);

            youTrackClient.Received().Get<Issue>(Arg.Any<GetIssueRequest>());
        }

        [Test]
        public void IssueExists()
        {
            youTrackClient.Get<Issue>(Arg.Any<GetIssueRequest>()).Returns(issue);

            Assert.IsTrue(Sut.IssueExists(IssueId));
        }

        [Test]
        public void IssueDoesNotExist()
        {
            youTrackClient.When(x => x.Get<Issue>(Arg.Any<GetIssueRequest>())).Do(x =>
                                                                                      {
                                                                                          throw new RequestNotFoundException(Mock<IRestResponse>());
                                                                                      });

            Assert.IsFalse(Sut.IssueExists(IssueId));
        }
    }
}
