using System.Collections.Generic;

namespace YouTrack.Rest.Repositories
{
    public interface IIssueRepository
    {
        IIssue CreateIssue(string project, string summary, string description, string group = null);
        IIssue GetIssue(string issueId);
        IEnumerable<IIssue> Search(string query);
        IEnumerable<IIssue> Search(string query, params string[] withFields);
        IEnumerable<IIssue> Search(string query, int maximumNumberOfRecordsToReturn, int startFrom);
        IEnumerable<IIssue> Search(string query, string[] withFields, int maximumNumberOfRecordsToReturn, int startFrom);
        void DeleteIssue(string issueId);
        bool IssueExists(string issueId);
    }
}