using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Tests.Repositories
{
    class ProjectRepositoryTests : TestFor<ProjectRepository>
    {
        private const string ProjectId = "projectId";

        protected override ProjectRepository CreateSut()
        {
            return new ProjectRepository(Mock<IConnection>());
        }

        [Test]
        public void ProjectProxyIsReturned()
        {
            Assert.That(Sut.GetProjectProxy(ProjectId), Is.TypeOf<ProjectProxy>());
        }

        [Test]
        public void ProjectIdIsAssignedToProxy()
        {
            IProjectProxy projectProxy = Sut.GetProjectProxy(ProjectId);

            Assert.That(projectProxy.Id, Is.EqualTo(ProjectId));
        }
    }
}
