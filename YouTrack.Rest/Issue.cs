using System;
using System.Collections.Generic;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class Issue : IIssue
    {
        private readonly IConnection connection;

        public string Id { get; private set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string ProjectShortName { get; set; }
        public string Description { get; internal set; }
        public int NumberInProject { get; internal set; }
        public DateTime Created { get; internal set; }
        public DateTime Updated { get; internal set; }
        public string UpdaterName { get; internal set; }
        public string ReporterName { get; internal set; }
        public int VotesCount { get; internal set; }
        public int CommentsCount { get; internal set; }
        public string Priority { get; internal set; }
        public string State { get; internal set; }
        public string Subsystem { get; internal set; }

        public Issue(string issueId, IConnection connection)
        {
            Id = issueId;
            this.connection = connection;
        }

        public void AttachFile(string filePath)
        {
            AttachFileToAnIssueRequest request = new AttachFileToAnIssueRequest(Id, filePath);

            connection.PostWithFile(request);
        }

        public IEnumerable<IAttachment> GetAttachments()
        {
            GetAttachmentsOfAnIssueRequest request = new GetAttachmentsOfAnIssueRequest(Id);
            FileUrlsWrapper fileUrlsWrapper = connection.Get<FileUrlsWrapper>(request);

            return fileUrlsWrapper.FileUrls;
        }

        public void AddComment(string comment)
        {
            AddCommentToIssueRequest addCommentToIssueRequest = new AddCommentToIssueRequest(Id, comment);

            connection.Post(addCommentToIssueRequest);
        }

        public IEnumerable<IComment> GetComments()
        {
            GetCommentsOfAnIssueRequest getCommentsOfAnIssueRequest = new GetCommentsOfAnIssueRequest(Id);

            CommentsWrapper commentsWrapper = connection.Get<CommentsWrapper>(getCommentsOfAnIssueRequest);

            return commentsWrapper.Comments;
        }
    }
}