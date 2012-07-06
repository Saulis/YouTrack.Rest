using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests.Repositories
{
    class ProjectRepositoryTests : TestFor<ProjectRepository>
    {
        private IConnection connection;
        private IProjectFactory projectFactory;
        private const string ProjectId = "projectId";

        protected override ProjectRepository CreateSut()
        {
            connection = Mock<IConnection>();
            projectFactory = Mock<IProjectFactory>();

            return new ProjectRepository(connection, projectFactory);
        }

        [Test]
        public void ProjectIsCreated()
        {
            IProject project = Sut.GetProject(ProjectId);

            projectFactory.Received().CreateProject(ProjectId, connection);
        }

        [Test]
        public void ProjectExists()
        {
            Sut.ProjectExists("foobar");

            connection.Received().Get(Arg.Any<GetProjectRequest>());
        }

        [Test]
        public void ProjectDoesNotExist()
        {
            connection.When(x => x.Get(Arg.Any<GetProjectRequest>())).Do(x =>
            {
                throw new RequestNotFoundException(Mock<IRestResponse>());
            });

            Assert.IsFalse(Sut.ProjectExists("foo"));
        }

        [Test]
        public void CreateNewProjectRequestIsUsed()
        {
            Sut.CreateProject(ProjectId, "foo", "bar", 1, "desc");

            connection.Received().Put(Arg.Any<CreateNewProjectRequest>());
        }

        [Test]
        public void DeleteProjectRequestIsUsed()
        {
            Sut.DeleteProject("foobar");

            connection.Delete(Arg.Any<DeleteProjectRequest>());
        }
    }
}
