using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Repositories
{
    internal class IssueRepositoryTests : TestFor<IssueRepository>
    {
        private const string Project = "project";
        private const string Summary = "summary";
        private const string Description = "description";
        private IYouTrackClient youTrackClient;

        protected override IssueRepository CreateSut()
        {
            youTrackClient = Mock<IYouTrackClient>();

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
        public void IssueIsCreatedOnCreateIssue()
        {
            Sut.CreateIssue(Project, Summary, Description);

            youTrackClient.Received().Put(Arg.Any<CreateNewIssueRequest>());
        }
    }
}
