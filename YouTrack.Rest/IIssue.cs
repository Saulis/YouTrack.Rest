using System;
using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssue : IIssueActions
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

        IDictionary<string, IEnumerable<string>> Fields { get; }
        bool HasField(string fieldName);
        string GetFieldValue(string fieldName);
        IEnumerable<string> GetFieldValues(string fieldName);
    }
}
