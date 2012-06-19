using System;
using System.Collections.Generic;
using System.Linq;
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

        public string CreateIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            CreateNewIssueRequest createNewIssueRequest = new CreateNewIssueRequest(project, summary, description, attachments, permittedGroup);

            string location = connection.Put(createNewIssueRequest);
            string issueId = location.Split('/').Last();

            return issueId;
        }

        public IIssue CreateAndGetIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            string issueId = CreateIssue(project, summary, description, attachments, permittedGroup);

            return GetIssue(issueId);
        }

        public IIssue GetIssue(string issueId)
        {
            GetIssueRequest getIssueRequest = new GetIssueRequest(issueId);

            IssueWrapper issueWrapper = connection.Get<IssueWrapper>(getIssueRequest);

            return issueWrapper.Deserialize(connection);
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
