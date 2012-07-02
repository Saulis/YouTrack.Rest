using NUnit.Framework;
using YouTrack.Rest.Factories;

namespace YouTrack.Rest.Tests.Factories
{
    class ProjectFactoryTests : TestFor<ProjectFactory>
    {
        private const string ProjectId = "FOO-BAR";

        [Test]
        public void ProjectProxyIsCreated()
        {
            IProject project = Sut.CreateProject(ProjectId, Mock<IConnection>());

            Assert.That(project.GetType().Name, Is.EqualTo("IProjectProxy"));
        }

        [Test]
        public void ProjectIdIsAssigned()
        {
            IProject project = Sut.CreateProject(ProjectId, Mock<IConnection>());

            Assert.That(project.Id, Is.EqualTo(ProjectId));
        }
    }
}