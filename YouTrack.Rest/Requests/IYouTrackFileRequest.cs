namespace YouTrack.Rest.Requests
{
    public interface IYouTrackFileRequest : IYouTrackRequest
    {
        string FilePath { get; }
        string Name { get; }
        byte[] Bytes { get; }
        string FileName { get; }
        bool HasBytes { get; }
    }
}