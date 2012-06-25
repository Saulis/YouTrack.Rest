using System;
using System.IO;

namespace YouTrack.Rest.Requests
{
    class AttachFileToAnIssueRequest : YouTrackRequest, IYouTrackPostWithFileRequest
    {
        private byte[] bytes;

        public AttachFileToAnIssueRequest(string issueId, string filePath) : base(String.Format("/rest/issue/{0}/attachment", issueId))
        {
            FilePath = filePath;
            Name = "files";

            ResourceBuilder.AddParameter("name", Path.GetFileNameWithoutExtension(filePath));
        }

        public AttachFileToAnIssueRequest(string issueId, string fileName, byte[] bytes) : base(String.Format("/rest/issue/{0}/attachment", issueId))
        {
            Name = "files";
            this.bytes = bytes;
            FileName = fileName;

            ResourceBuilder.AddParameter("name", fileName);
        }

        public string FilePath { get; private set; }
        public string Name { get; private set; }
        public string FileName { get; private set; }

        public byte[] Bytes
        {
            get { return bytes; }
        }


        public bool HasBytes
        {
            get { return bytes != null; }
        }
    }
}
