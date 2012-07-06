using System;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest
{
    public interface IConnection
    {
        string Put(IYouTrackPutRequest request);
        TResponse Get<TResponse>(IYouTrackGetRequest request) where TResponse : new();
        void Get(IYouTrackGetRequest request);
        void Delete(IYouTrackDeleteRequest request);
        void Post(IYouTrackPostRequest request);
        void PostWithFile(IYouTrackPostWithFileRequest request);
        void GetAsync<TResponse>(IYouTrackGetRequest request, Action<TResponse> onSuccess);
    }
}