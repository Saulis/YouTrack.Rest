namespace YouTrack.Rest.Repositories
{
    public interface IIssueRepository
    {
        string CreateIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null);
        IIssue CreateAndGetIssue(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null);
        IIssue GetIssue(string issueId);
        void DeleteIssue(string issueId);
        bool IssueExists(string issueId);
        void AddComment(string issueId, string comment);
    }
}