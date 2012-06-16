using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Features.Steps
{
    public class StepHelper
    {
        private YouTrackClient youTrackClient;

        public IConnection GetConnection()
        {
            return youTrackClient.GetConnection();
        }

        public void InitializeYouTrackClient(string baseUrl, string login, string password)
        {
            youTrackClient = new YouTrackClient(baseUrl, login, password);
        }

        public string CreateIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            return issueRepository.CreateIssue(project, summary, description, attachments, permittedGroup);
        }

        public IIssue CreateAndGetIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            return issueRepository.CreateAndGetIssue(project, summary, description, attachments, permittedGroup);
        }
    }
}