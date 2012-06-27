namespace YouTrack.Rest
{
    public interface IComment
    {
        string Id { get; }
        string Text { get; }
        string IssueId { get; }
    }
}
