namespace YouTrack.Rest.Repositories
{
    public interface IIssueRepository
    {
        IIssue CreateIssue(string project, string summary, string description);
        IIssue GetIssue(string issueId);
        void DeleteIssue(string issueId);
        bool IssueExists(string issueId);
    }
}