using System;
using System.Collections.Generic;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest
{
    public interface IIssue : ILoadable
    {
        string Summary { get; }
        string Type { get; }
        string ProjectShortName { get; }
        string Description { get; }
        string Priority { get; }
        string State { get; }
        string Subsystem { get; }
        int NumberInProject { get; }
        DateTime Created { get; }
        DateTime Updated { get; }
        string UpdaterName { get; }
        string ReporterName { get; }
        int VotesCount { get; }
        int CommentsCount { get; }
        void AttachFile(string filePath);
        IEnumerable<IAttachment> GetAttachments();
        void AddComment(string comment);
        void RemoveComment(string commentId);
        IEnumerable<IComment> Comments { get; }
        void SetSubsystem(string subsystem);
        void SetType(string type);
        void AttachFile(string fileName, byte[] bytes);
        void ApplyCommand(string command);
        void ApplyCommands(params string[] commands);
    }
}
