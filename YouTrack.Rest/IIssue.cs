namespace YouTrack.Rest
{
    public interface IIssue
    {
        string Id { get; }
        string Summary { get; }
        string Type { get; }
        string ProjectShortName { get; }
    }
}
