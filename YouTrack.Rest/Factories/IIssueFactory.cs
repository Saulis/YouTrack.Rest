namespace YouTrack.Rest.Factories
{
    public interface IIssueFactory
    {
        IIssue CreateIssue(string issueId, IConnection connection);
    }
}