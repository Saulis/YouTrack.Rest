namespace YouTrack.Rest.Repositories
{
    public interface IIssueRepository
    {
        IIssueProxy CreateIssue(string project, string summary, string description);
        IIssue CreateAndGetIssue(string project, string summary, string description);
        IIssue GetIssue(string issueId);
        void DeleteIssue(string issueId);
        bool IssueExists(string issueId);
        IIssueProxy GetIssueProxy(string issueId);
    }
}