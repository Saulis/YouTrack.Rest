namespace YouTrack.Rest
{
    public interface IIssue : IIssueProxy
    {
        string Summary { get; }
        string Type { get; }
        string ProjectShortName { get; }
    }
}
