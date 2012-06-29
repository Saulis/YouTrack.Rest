using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class Issue : ILoadable, IIssue
    {
        public string Id { get; private set; }
        private bool isLoaded;
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

        bool ILoadable.IsLoaded
        {
            get { return isLoaded; }
        }

        void ILoadable.Load()
        {
            GetIssueRequest request = new GetIssueRequest(Id);

            Deserialization.Issue issue = Connection.Get<Deserialization.Issue>(request);

            issue.MapTo(this, Connection);

            isLoaded = true;
        }

        public Issue(string issueId, IConnection connection)
        {
            Id = issueId;
            Connection = connection;
            isLoaded = false;
        }

        private IEnumerable<IComment> comments;

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

            return commentsCollection.GetComments(Connection);
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

        public void RemoveComment(string commentId)
        {
            RemoveACommentForAnIssueRequest request = new RemoveACommentForAnIssueRequest(Id, commentId);

            Connection.Delete(request);

            //Force fetching when comments are needed next time.
            comments = null;
        }
    }
}