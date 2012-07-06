using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class ProjectProxy : IProjectProxy
    {
        private readonly IConnection connection;
        private readonly IIssueRequestFactory issueRequestFactory;

        public ProjectProxy(string projectId, IConnection connection, IIssueRequestFactory issueRequestFactory)
        {
            Id = projectId;
            this.connection = connection;
            this.issueRequestFactory = issueRequestFactory;
        }

        public string Id { get; private set; }

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
            List<Deserialization.Issue> issues = connection.Get<List<Deserialization.Issue>>(request);

            return issues.Select(i => i.GetIssue(connection, issueRequestFactory));
        }
    }
}