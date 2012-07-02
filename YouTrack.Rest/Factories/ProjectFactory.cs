namespace YouTrack.Rest.Factories
{
    class ProjectFactory : ProxyFactory, IProjectFactory
    {
        public IProject CreateProject(string projectId, IConnection connection)
        {
            Project project = new Project(projectId, connection);

            return CreateProxy<IProject>(project);
        }
    }
}
