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
    }
}