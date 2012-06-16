using System;
using System.Linq;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Repositories
{
    class IssueRepository : IIssueRepository
    {
        private readonly IYouTrackClient client;

        public IssueRepository(IYouTrackClient client)
        {
            this.client = client;
        }

        public string CreateIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            CreateNewIssueRequest createNewIssueRequest = new CreateNewIssueRequest(project, summary, description, attachments, permittedGroup);

            string location = client.Put(createNewIssueRequest);
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

            Issue issue = client.Get<Issue>(getIssueRequest);

            return issue;
        }

        public void DeleteIssue(string issueId)
        {
            DeleteIssueRequest deleteIssueRequest = new DeleteIssueRequest(issueId);

            client.Delete(deleteIssueRequest);
        }

        public bool IssueExists(string issueId)
        {
            try
            {
                //TODO: Better solution would be to use the Issue Count method.
                return GetIssue(issueId) != null;
            }
            catch (RequestNotFoundException)
            {
                return false;
            }
        }
    }
}
