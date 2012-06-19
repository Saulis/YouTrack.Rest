namespace YouTrack.Rest
{
    public interface IAttachment
    {
        string Url { get; }
        string Name { get; }
        string AuthorLogin { get; }
        string Group { get; }
    }
}
