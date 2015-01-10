namespace YouTrack.Rest.Repositories
{
    public interface IIssueRepository
    {
        IIssue CreateIssue(string project, string summary, string description, string group = null);
        IIssue GetIssue(string issueId);
        void DeleteIssue(string issueId);
        bool IssueExists(string issueId);
    }
}