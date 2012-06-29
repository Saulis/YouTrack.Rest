using System.Linq;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Repositories
{
    class IssueRepository : IIssueRepository
    {
        private readonly IConnection connection;
        private readonly IIssueFactory issueFactory;

        public IssueRepository(IConnection connection, IIssueFactory issueFactory)
        {
            this.connection = connection;
            this.issueFactory = issueFactory;
        }

        public IIssue CreateIssue(string project, string summary, string description)
        {
            CreateNewIssueRequest createNewIssueRequest = new CreateNewIssueRequest(project, summary, description);

            string location = connection.Put(createNewIssueRequest);
            string issueId = location.Split('/').Last();

            return issueFactory.CreateIssue(issueId, connection);
        }

        public IIssue GetIssue(string issueId)
        {
            return issueFactory.CreateIssue(issueId, connection);
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
    }
}
