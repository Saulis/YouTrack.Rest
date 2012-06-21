using System;
using System.Collections.Generic;
using System.IO;
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

        public IIssueProxy CreateIssue(string project, string summary, string description)
        {
            IIssueProxy issueProxy = GetIssueRepository().CreateIssue(project, summary, description);

            Console.WriteLine("Issue created with Id: {0}", issueProxy.Id);

            return issueProxy;
        }

        public IIssue CreateAndGetIssue(string project, string summary, string description)
        {
            IIssue issue = GetIssueRepository().CreateAndGetIssue(project, summary, description);

            Console.WriteLine("Issue created with Id: {0}", issue.Id);

            return issue;

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

        public void AddCommentToIssue(IIssueProxy issueProxy, string comment)
        {
            Console.WriteLine("Adding comment {0} to Issue with Id: {1}", comment, issueProxy.Id);

            issueProxy.AddComment(comment);
        }

        private IIssueRepository GetIssueRepository()
        {
            return youTrackClient.GetIssueRepository();
        }

        public IEnumerable<IComment> GetComments(IIssueProxy issueProxy)
        {
            Console.WriteLine("Getting comments for issue with Id: {0}", issueProxy.Id);

            return issueProxy.GetComments();
        }

        public void AttachFile(IIssueProxy issueProxy, string filePath)
        {
            Console.WriteLine("Attaching file {0} for Issue with Id: {1}", filePath, issueProxy.Id);

            issueProxy.AttachFile(filePath);

        }

        public IEnumerable<IAttachment> GetAttachments(IIssueProxy issueProxy)
        {
            Console.WriteLine("Getting attachments for Issue with Id: {0}", issueProxy.Id);

            return issueProxy.GetAttachments();
        }

        public IIssueProxy GetIssueProxy(string issueId)
        {
            return GetIssueRepository().GetIssueProxy(issueId);
        }
    }
}