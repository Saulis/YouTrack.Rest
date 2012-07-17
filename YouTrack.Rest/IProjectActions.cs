using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IProjectActions
    {
        string Id { get; }
        IEnumerable<IIssue> GetIssues();
        IEnumerable<IIssue> GetIssues(string filter);
        IEnumerable<ISubsystem> Subsystems { get; }
        void AddSubsystem(string subsystem);
    }
}