using System;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Features.Steps
{
    public class StepHelper
    {
        private IYouTrackClient youTrackClient;

        public void InitializeYouTrackClient(string baseUrl, string login, string password)
        {
            youTrackClient = new YouTrackClient(baseUrl, login, password);
        }

        public string CreateIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            string issueId = issueRepository.CreateIssue(project, summary, description, attachments, permittedGroup);

            Console.WriteLine("Issue created with Id: {0}", issueId);


            return issueId;
        }

        public IIssue CreateAndGetIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            return issueRepository.CreateAndGetIssue(project, summary, description, attachments, permittedGroup);
        }

        public void DeleteIssue(string issueId)
        {
            Console.WriteLine("Deleting Issue with Id: {0}", issueId);

            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            issueRepository.DeleteIssue(issueId);
        }

        public bool IssueExists(string issueId)
        {
            Console.WriteLine("Checking if Issue exists for Id: {0}", issueId);

            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            return issueRepository.IssueExists(issueId);
        }

        public IIssue GetIssue(string issueId)
        {
            Console.WriteLine("Getting Issue with Id: {0}", issueId);

            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            return issueRepository.GetIssue(issueId);
        }

        public ISession GetSession()
        {
            return youTrackClient.GetSession();
        }
    }
}