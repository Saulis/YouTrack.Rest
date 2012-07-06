using NUnit.Framework;

namespace YouTrack.Rest.Tests.Deserialization
{
    class ProjectDeserializationTests : TestFor<Rest.Deserialization.Project>
    {
        private const string Description = "description";
        private const string Name = "name";
        private const string ProjectLeadLogin = "projectLead";
        private Project project;

        protected override Rest.Deserialization.Project CreateSut()
        {
            Rest.Deserialization.Project sut = new Rest.Deserialization.Project();

            sut.Name = Name;
            sut.Lead = ProjectLeadLogin;
            sut.Description = Description;

            return sut;
        }

        protected override void SetupDependencies()
        {
            project = new Project("FOO", Mock<IConnection>());
        }

        [Test]
        public void DescriptionIsMapped()
        {
            Sut.MapTo(project);

            Assert.That(project.Description, Is.EqualTo(Description));
        }

        [Test]
        public void NameIsMapped()
        {
            Sut.MapTo(project);

            Assert.That(project.Name, Is.EqualTo(Name));
        }

        [Test]
        public void ProjectLeadLoginIsMapped()
        {
            Sut.MapTo(project);

            Assert.That(project.ProjectLeadLogin, Is.EqualTo(ProjectLeadLogin));
        }
    }
}
