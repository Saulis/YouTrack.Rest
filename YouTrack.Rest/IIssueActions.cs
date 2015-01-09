using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssueActions
    {
        string Id { get; }
        void AttachFile(string filePath);
        IEnumerable<IAttachment> GetAttachments();
        void AddComment(string comment);
        void AddComment(string comment, string group);
        void RemoveComment(string commentId);
        IEnumerable<IComment> Comments { get; }
        void SetSubsystem(string subsystem);
        void SetType(string type);
        void AttachFile(string fileName, byte[] bytes);
        void ApplyCommand(string command);
        void ApplyCommands(params string[] commands);
    }
}