using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests.Issues;

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

        public IIssue CreateIssue(string project, string summary, string description, string group = null)
        {
            CreateNewIssueRequest createNewIssueRequest = new CreateNewIssueRequest(project, summary, description, group);

            string location = connection.Put(createNewIssueRequest);
            string issueId = location.Split('/').Last();

            return GetIssue(issueId);
        }

        public IIssue GetIssue(string issueId)
        {
            return issueFactory.CreateIssue(issueId, connection);
        }

        public IEnumerable<IIssue> Search(string query)
        {
            SearchRequest searchRequest = new SearchRequest(query);

            return Search(searchRequest);
        }

        public IEnumerable<IIssue> Search(string query, params string[] withFields)
        {
            SearchRequest searchRequest = new SearchRequest(query, withFields);

            return Search(searchRequest);
        }

        public IEnumerable<IIssue> Search(string query, int maximumNumberOfRecordsToReturn, int startFrom)
        {
            SearchRequest searchRequest = new SearchRequest(query, null, maximumNumberOfRecordsToReturn, startFrom);

            return Search(searchRequest);
        }

        public IEnumerable<IIssue> Search(string query, string[] withFields, int maximumNumberOfRecordsToReturn, int startFrom)
        {
            SearchRequest searchRequest = new SearchRequest(query, withFields, maximumNumberOfRecordsToReturn, startFrom);

            return Search(searchRequest);
        }

        private IEnumerable<IIssue> Search(SearchRequest request)
        {
            List<Deserialization.Issue> issues = connection.Get<List<Deserialization.Issue>>(request);

            return issues.Select(i => i.GetIssue(connection));
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
