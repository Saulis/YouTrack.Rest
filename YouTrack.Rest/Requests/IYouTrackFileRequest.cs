namespace YouTrack.Rest.Requests
{
    public interface IYouTrackFileRequest : IYouTrackRequest
    {
        string FilePath { get; }
        string Name { get; }
    }
}