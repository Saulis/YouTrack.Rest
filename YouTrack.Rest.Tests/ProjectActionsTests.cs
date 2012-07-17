using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests.Issues;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests
{
    class ProjectActionsTests : TestFor<ProjectActions>
    {
        private IConnection connection;
        private List<Rest.Deserialization.Issue> deserializedIssues;
        private Rest.Deserialization.Issue deserializedIssue;
        private SubsystemCollection subsystemCollection;
        private const string ProjectId = "FOOBAR";

        protected override ProjectActions CreateSut()
        {
            connection = Mock<IConnection>();
            return new ProjectActions(ProjectId, connection);
        }

        protected override void SetupDependencies()
        {
            deserializedIssues = new List<Rest.Deserialization.Issue>();
            deserializedIssue = Mock<Rest.Deserialization.Issue>();
            deserializedIssues.Add(deserializedIssue);

            connection.Get<List<Rest.Deserialization.Issue>>(Arg.Any<GetIssuesInAProjectRequest>()).Returns(deserializedIssues);

            subsystemCollection = Mock<SubsystemCollection>();
            subsystemCollection.Subsystems.Returns(new List<Subsystem>());
        }

        [Test]
        public void IdIsAssigned()
        {
            Assert.That(Sut.Id, Is.EqualTo(ProjectId));
        }

        [Test]
        public void ConnectionIsCalledOnGetIssues()
        {
            Sut.GetIssues();

            connection.Received().Get<List<Rest.Deserialization.Issue>>(Arg.Any<GetIssuesInAProjectRequest>());
        }

        [Test]
        public void GetIssueIsCalledOnEachIssue()
        {
            IEnumerable<IIssue> issues = Sut.GetIssues().ToList();

            deserializedIssue.Received().GetIssue(connection);
        }

        [Test]
        public void ConnectionIsCalledOnGetIssuesWithFilter()
        {
            Sut.GetIssues("filter");

            connection.Received().Get<List<Rest.Deserialization.Issue>>(Arg.Any<GetIssuesInAProjectRequest>());
        }

        [Test]
        public void ConnectionCalledOnGetSubsystems()
        {
            IEnumerable<ISubsystem> subsystems = Sut.Subsystems;

            connection.Received().Get<SubsystemCollection>(Arg.Any<GetProjectSubsystemsRequest>());
        }

        [Test]
        public void SubsystemAreCached()
        {
            connection.Get<SubsystemCollection>(Arg.Any<GetProjectSubsystemsRequest>()).Returns(subsystemCollection);

            IEnumerable<ISubsystem> subsystems = Sut.Subsystems;
            subsystems = Sut.Subsystems;

            connection.Received(1).Get<SubsystemCollection>(Arg.Any<GetProjectSubsystemsRequest>());
        }
    }
}
