using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class Issue : IIssue
    {
        private readonly IConnection connection;
        private IEnumerable<IAttachment> attachments;

        public string Id { get; private set; }
        public string Summary { get; set; }
        public string Type { get; set; }
        public string ProjectShortName { get; set; }

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
            if (attachments == null)
            {
                GetAttachmentsOfAnIssueRequest request = new GetAttachmentsOfAnIssueRequest(Id);
                FileUrlsWrapper fileUrlsWrapper = connection.Get<FileUrlsWrapper>(request);

                attachments = fileUrlsWrapper.FileUrls;
            }

            return attachments;
        }
    }
}