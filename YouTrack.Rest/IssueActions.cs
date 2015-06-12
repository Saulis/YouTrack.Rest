using System.Collections.Generic;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest
{
    abstract class IssueActions : IIssueActions
    {
        private IEnumerable<IComment> comments;

        protected IssueActions(string issueId, IConnection connection)
        {
            Id = issueId;
            Connection = connection;
        }

        public IEnumerable<IComment> Comments
        {
            get { return comments ?? (comments = GetComments()); }
            internal set { comments = value; }
        }

        public string Id { get; private set; }
        protected IConnection Connection { get; private set; }

        private IEnumerable<IComment> GetComments()
        {
            GetCommentsOfAnIssueRequest request = new GetCommentsOfAnIssueRequest(Id);

            CommentCollection commentCollection = Connection.Get<CommentCollection>(request);

            return commentCollection.GetComments(Connection);
        }

        public virtual void ApplyCommand(string command, string group = null)
        {
            ApplyCommandToAnIssueRequest request = new ApplyCommandToAnIssueRequest(Id, command, group: group);

            Connection.Post(request);
        }

        public virtual void ApplyCommands(params string[] commands)
        {
            ApplyCommandsToAnIssueRequest request = new ApplyCommandsToAnIssueRequest(Id, commands);

            Connection.Post(request);
        }

        private IEnumerable<IChange> changes; 

        public IEnumerable<IChange> ChangeHistory
        {
            get { return changes ?? (changes = GetChanges()); }
        }

        private IEnumerable<IChange> GetChanges()
        {
            GetChangeHistoryOfAnIssueRequest request = new GetChangeHistoryOfAnIssueRequest(Id);

            ChangeCollection changeCollection = Connection.Get<ChangeCollection>(request);

            return changeCollection.GetChanges(Connection);
        }

        public void SetSubsystem(string subsystem, string group = null)
        {
            ApplyCommand(Commands.SetSubsystem(subsystem), group);
        }

        public void SetType(string type, string group = null)
        {
            ApplyCommand(Commands.SetType(type), group);
        }

        public void AttachFile(string fileName, byte[] bytes, string group = null)
        {
            AttachFileToAnIssueRequest request = new AttachFileToAnIssueRequest(Id, fileName, bytes, group);

            Connection.PostWithFile(request);
        }

        public void AttachFile(string filePath, string group = null)
        {
            AttachFileToAnIssueRequest request = new AttachFileToAnIssueRequest(Id, filePath, group);

            Connection.PostWithFile(request);
        }

        public IEnumerable<IAttachment> GetAttachments()
        {
            GetAttachmentsOfAnIssueRequest request = new GetAttachmentsOfAnIssueRequest(Id);
            FileUrlCollection fileUrlCollection = Connection.Get<FileUrlCollection>(request);

            return fileUrlCollection.FileUrls;
        }

        public void AddComment(string comment, string group = null)
        {
            Connection.Post(new AddCommentToIssueRequest(Id, comment, group));

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