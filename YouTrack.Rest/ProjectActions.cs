using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests.Issues;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest
{
    class ProjectActions : IProjectActions
    {
        private IEnumerable<ISubsystem> subsystems;

        public ProjectActions(string projectId, IConnection connection)
        {
            Id = projectId;
            Connection = connection;
        }

        protected IConnection Connection { get; private set; }
        public string Id { get; private set; }

        public IEnumerable<ISubsystem> Subsystems
        {
            get { return subsystems ?? (subsystems = GetSubsystems()); }
        }

        public void AddSubsystem(string subsystem)
        {
            AddSubsystemToProjectRequest request = new AddSubsystemToProjectRequest(Id, subsystem);

            Connection.Put(request);

            subsystems = null;
        }

        private IEnumerable<ISubsystem> GetSubsystems()
        {
            GetProjectSubsystemsRequest request = new GetProjectSubsystemsRequest(Id);

            SubsystemCollection subsystemCollection = Connection.Get<SubsystemCollection>(request);

            return subsystemCollection.Subsystems;
        }

        public IEnumerable<IIssue> GetIssues()
        {
            GetIssuesInAProjectRequest request = new GetIssuesInAProjectRequest(Id);

            return GetIssues(request);
        }

        public IEnumerable<IIssue> GetIssues(string filter)
        {
            GetIssuesInAProjectRequest request = new GetIssuesInAProjectRequest(Id, filter);

            return GetIssues(request);
        }


        private IEnumerable<IIssue> GetIssues(GetIssuesInAProjectRequest request)
        {
            List<Deserialization.Issue> issues = Connection.Get<List<Deserialization.Issue>>(request);

            return issues.Select(i => i.GetIssue(Connection));
        }
    }
}