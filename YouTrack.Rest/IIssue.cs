using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssue : IIssueProxy
    {
        string Summary { get; }
        string Type { get; }
        string ProjectShortName { get; }
    }

    public interface IIssueProxy
    {
        string Id { get; }
        void AttachFile(string filePath);
        IEnumerable<IAttachment> GetAttachments();
    }
}
