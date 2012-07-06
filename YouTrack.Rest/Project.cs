using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest
{
    public interface IProjectActions
    {
        string Id { get; }
    }

    class ProjectActions : IProjectActions
    {
        public ProjectActions(string projectId, IConnection connection)
        {
            Id = projectId;
            Connection = connection;
        }

        public string Id { get; private set; }
        protected IConnection Connection { get; private set; }
    }

    class Project : ProjectActions, IProject, ILoadable
    {
        public Project(string projectId, IConnection connection) : base(projectId, connection)
        {
        }

        public string Description { get; internal set; }
        public string Name { get; internal set; }
        public int StartingNumber { get; internal set; }
        public string ProjectLeadLogin { get; internal set; }

        public bool IsLoaded { get; private set; }

        public void Load()
        {
            GetProjectRequest request = new GetProjectRequest(Id);

            Deserialization.Project project = Connection.Get<Deserialization.Project>(request);

            project.MapTo(this);

            IsLoaded = true;
        }
    }
}
