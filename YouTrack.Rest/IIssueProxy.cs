using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssueProxy
    {
        string Id { get; }
        void AttachFile(string filePath);
        IEnumerable<IAttachment> GetAttachments();
        void AddComment(string comment);
        IEnumerable<IComment> Comments { get; }
        void SetSubsystem(string subsystem);
        void SetType(string type);
        void AttachFile(string fileName, byte[] bytes);
        void ApplyCommand(string command);
        void ApplyCommands(params string[] commands);
    }
}