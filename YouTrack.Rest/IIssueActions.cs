using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssueActions
    {
        string Id { get; }
        void AttachFile(string filePath, string group = null);
        void AttachFile(string fileName, byte[] bytes, string group = null);
        IEnumerable<IAttachment> GetAttachments();
        void AddComment(string comment);
        void AddComment(string comment, string group);
        void RemoveComment(string commentId);
        IEnumerable<IComment> Comments { get; }
        void SetSubsystem(string subsystem);
        void SetSubsystem(string subsystem, string group);
        void SetType(string type);
        void SetType(string type, string group);
        void ApplyCommand(string command);
        void ApplyCommand(string command, string group);
        void ApplyCommands(params string[] commands);
    }
}