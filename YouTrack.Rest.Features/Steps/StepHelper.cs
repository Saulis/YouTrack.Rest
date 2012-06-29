using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public IIssue CreateIssue(string project, string summary, string description)
        {
            IIssue issue = GetIssueRepository().CreateIssue(project, summary, description);

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

        public void AddCommentToIssue(IIssue issue, string comment)
        {
            Console.WriteLine("Adding comment {0} to Issue with Id: {1}", comment, issue.Id);

            issue.AddComment(comment);
        }

        private IIssueRepository GetIssueRepository()
        {
            return youTrackClient.GetIssueRepository();
        }

        public IEnumerable<IComment> GetComments(IIssue issue)
        {
            Console.WriteLine("Getting comments for issue with Id: {0}", issue.Id);

            return issue.Comments;
        }

        public void AttachFile(IIssue issue, string filePath)
        {
            Console.WriteLine("Attaching file {0} for Issue with Id: {1}", filePath, issue.Id);

            issue.AttachFile(filePath);

        }

        public void AttachFile(IIssue issue, byte[] bytes, string fileName)
        {
            Console.WriteLine("Attaching file {0} for Issue with Id: {1}", fileName, issue.Id);

            issue.AttachFile(fileName, bytes);
        }

        public IEnumerable<IAttachment> GetAttachments(IIssue issue)
        {
            Console.WriteLine("Getting attachments for Issue with Id: {0}", issue.Id);

            return issue.GetAttachments();
        }

        public IEnumerable<IIssue> GetIssues(string project, string filter)
        {
            IProjectProxy projectProxy = GetProjectRepository().GetProjectProxy(project);

            return projectProxy.GetIssues(filter);
        }

        public IEnumerable<IIssue> GetIssues(string project)
        {
            IProjectProxy projectProxy = GetProjectRepository().GetProjectProxy(project);

            return projectProxy.GetIssues();
        }

        private IProjectRepository GetProjectRepository()
        {
            return youTrackClient.GetProjectRepository();
        }

        public void RemoveCommentForIssue(IIssue issue)
        {
            IEnumerable<IComment> comments = issue.Comments;
            string commentId = comments.Single().Id;

            Console.WriteLine("Removing comment {0} for Issue with Id: {1}", commentId, issue.Id);

            issue.RemoveComment(commentId);
        }
    }
}