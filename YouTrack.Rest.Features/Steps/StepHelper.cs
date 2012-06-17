using System;
using System.Collections.Generic;
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
            string issueId = GetIssueRepository().CreateIssue(project, summary, description, attachments, permittedGroup);

            Console.WriteLine("Issue created with Id: {0}", issueId);

            return issueId;
        }

        public IIssue CreateAndGetIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null)
        {
            return GetIssueRepository().CreateAndGetIssue(project, summary, description, attachments, permittedGroup);
        }

        public void DeleteIssue(string issueId)
        {
            Console.WriteLine("Deleting Issue with Id: {0}", issueId);

            GetIssueRepository().DeleteIssue(issueId);
        }

        public bool IssueExists(string issueId)
        {
            Console.WriteLine("Checking if Issue exists for Id: {0}", issueId);

            return GetIssueRepository().IssueExists(issueId);
        }

        public IIssue GetIssue(string issueId)
        {
            Console.WriteLine("Getting Issue with Id: {0}", issueId);

            return GetIssueRepository().GetIssue(issueId);
        }

        public ISession GetSession()
        {
            return youTrackClient.GetSession();
        }

        public void AddCommentToIssue(string issueId, string comment)
        {
            Console.WriteLine("Adding comment {0} to Issue with Id: {1}", comment, issueId);

            GetIssueRepository().AddComment(issueId, comment);
        }

        private IIssueRepository GetIssueRepository()
        {
            return youTrackClient.GetIssueRepository();
        }

        public IEnumerable<IComment> GetComments(string issueId)
        {
            return GetIssueRepository().GetComments(issueId);
        }
    }
}