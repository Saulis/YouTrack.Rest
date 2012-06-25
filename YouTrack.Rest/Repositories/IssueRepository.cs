using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Repositories
{
    class IssueRepository : IIssueRepository
    {
        private readonly IConnection connection;

        public IssueRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public IIssueProxy CreateIssue(string project, string summary, string description)
        {
            CreateNewIssueRequest createNewIssueRequest = new CreateNewIssueRequest(project, summary, description);

            string location = connection.Put(createNewIssueRequest);
            string issueId = location.Split('/').Last();

            return new Issue(issueId, connection);
        }

        public IIssue CreateAndGetIssue(string project, string summary, string description)
        {
            string issueId = CreateIssue(project, summary, description).Id;

            return GetIssue(issueId);
        }

        public IIssue GetIssue(string issueId)
        {
            GetIssueRequest getIssueRequest = new GetIssueRequest(issueId);

            Deserialization.Issue issue = connection.Get<Deserialization.Issue>(getIssueRequest);

            return issue.GetIssue(connection);
        }

        public ICollection<IIssue> GetIssuesOfAnProject(string project, string filter)
        {
            GetIssuesInAProjectRequest request = new GetIssuesInAProjectRequest(project, filter);

            List<Deserialization.Issue> issues = connection.Get<List<Deserialization.Issue>>(request);

            return issues.Select(i => i.GetIssue(connection)).ToList();
        }

        public void DeleteIssue(string issueId)
        {
            DeleteIssueRequest deleteIssueRequest = new DeleteIssueRequest(issueId);

            connection.Delete(deleteIssueRequest);
        }

        public bool IssueExists(string issueId)
        {
            try
            {
                CheckIfIssueExistsRequest checkIfIssueExistsRequest = new CheckIfIssueExistsRequest(issueId);

                connection.Get(checkIfIssueExistsRequest);

                return true;
            }
            catch (RequestNotFoundException)
            {
                return false;
            }
        }

        public IIssueProxy GetIssueProxy(string issueId)
        {
            return new Issue(issueId, connection);
        }
    }
}
