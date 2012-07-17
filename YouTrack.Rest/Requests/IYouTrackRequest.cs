namespace YouTrack.Rest.Requests
{
    public interface IYouTrackRequest
    {
        string RestResource { get; }
        bool HasBody { get; }
        object Body { get; }
    }
}
