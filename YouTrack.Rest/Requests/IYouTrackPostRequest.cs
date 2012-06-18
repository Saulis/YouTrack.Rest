namespace YouTrack.Rest.Requests
{
    public interface IYouTrackPostRequest : IYouTrackRequest
    {
    }

    public interface IYouTrackPostWithFileRequest : IYouTrackPostRequest, IYouTrackFileRequest
    {
        
    }
}
