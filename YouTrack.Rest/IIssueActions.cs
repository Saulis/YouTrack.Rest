using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssueActions
    {
        string Id { get; }
        void AttachFile(string filePath, string group = null);
        void AttachFile(string fileName, byte[] bytes, string group = null);
        IEnumerable<IAttachment> GetAttachments();
        void AddComment(string comment, string group = null);
        void RemoveComment(string commentId);
        IEnumerable<IComment> Comments { get; }
        void SetSubsystem(string subsystem, string group = null);
        void SetType(string type, string group = null);
        void ApplyCommand(string command, string group = null);
        void ApplyCommands(params string[] commands);
    }
}