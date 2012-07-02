using YouTrack.Rest.Interception;

namespace YouTrack.Rest
{
    class Project : IProject, ILoadable
    {
        private IConnection connection;

        public Project(string projectId, IConnection connection)
        {
            Id = projectId;
            this.connection = connection;
        }

        public string Id { get; private set; }

        public bool IsLoaded { get; private set; }

        public void Load()
        {
            IsLoaded = true;
        }
    }
}
