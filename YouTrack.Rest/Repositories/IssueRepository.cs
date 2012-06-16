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

            return location;
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
    }
}
