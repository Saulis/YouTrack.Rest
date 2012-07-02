using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Repositories
{
    class ProjectRepository : IProjectRepository
    {
        private readonly IConnection connection;

        public ProjectRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public IProjectProxy GetProjectProxy(string projectid)
        {
            return new ProjectProxy(projectid, connection);
        }

        public void CreateProject(string projectId, string projectName, string projectLeadLogin, int startingNumber = 1, string description = null)
        {
            connection.Put(new CreateNewProjectRequest(projectId, projectName, projectLeadLogin, startingNumber, description));
        }

        public bool ProjectExists(string projectId)
        {
            //Relies on the "not found" exception if project doesn't exist. Could use some improving.

            try
            {
                connection.Get(new GetProjectRequest(projectId));

                return true;
            }
            catch (RequestNotFoundException)
            {
                return false;
            }
        }
    }
}