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
        IEnumerable<ICustomField> CustomFields { get; }

        string GetCustomFieldValue(string fieldName);
        IEnumerable<string> GetCustomFieldValues(string fieldName);
    }
}
