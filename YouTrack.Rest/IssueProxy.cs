using System;
using System.Collections.Generic;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class IssueProxy : IIssueProxy
    {
        public string Id { get; private set; }
        private IEnumerable<IComment> comments;

        public IssueProxy(string issueId, IConnection connection)
        {
            Id = issueId;
            Connection = connection;
        }

        protected IConnection Connection { get; private set; }

        public IEnumerable<IComment> Comments
        {
            get { return comments ?? (comments = GetComments()); }
            internal set { comments = value; }
        }

        private IEnumerable<IComment> GetComments()
        {
            GetCommentsOfAnIssueRequest request = new GetCommentsOfAnIssueRequest(Id);

            CommentsCollection commentsCollection = Connection.Get<CommentsCollection>(request);

            return commentsCollection.Comments;
        }

        public void ApplyCommand(string command)
        {
            ApplyCommandToAnIssueRequest request = new ApplyCommandToAnIssueRequest(Id, command);

            Connection.Post(request);
        }

        public void ApplyCommands(params string[] commands)
        {
            ApplyCommandsToAnIssueRequest request = new ApplyCommandsToAnIssueRequest(Id, commands);

            Connection.Post(request);
        }

        public void SetSubsystem(string subsystem)
        {
            ApplyCommand(Commands.SetSubsystem(subsystem));
        }

        public void SetType(string type)
        {
            ApplyCommand(Commands.SetType(type));
        }

        public void AttachFile(string fileName, byte[] bytes)
        {
            AttachFileToAnIssueRequest request = new AttachFileToAnIssueRequest(Id, fileName, bytes);

            Connection.PostWithFile(request);
        }

        public void AttachFile(string filePath)
        {
            AttachFileToAnIssueRequest request = new AttachFileToAnIssueRequest(Id, filePath);

            Connection.PostWithFile(request);
        }

        public IEnumerable<IAttachment> GetAttachments()
        {
            GetAttachmentsOfAnIssueRequest request = new GetAttachmentsOfAnIssueRequest(Id);
            FileUrlCollection fileUrlCollection = Connection.Get<FileUrlCollection>(request);

            return fileUrlCollection.FileUrls;
        }

        public void AddComment(string comment)
        {
            AddCommentToIssueRequest request = new AddCommentToIssueRequest(Id, comment);

            Connection.Post(request);

            //Force fetching when comments are needed next time.
            comments = null;
        }
    }
}