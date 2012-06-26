using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IProjectProxy
    {
        string Id { get; }
        IEnumerable<IIssue> GetIssues();
        IEnumerable<IIssue> GetIssues(string filter);
    }
}