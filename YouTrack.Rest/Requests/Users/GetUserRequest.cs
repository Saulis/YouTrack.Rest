using System;

namespace YouTrack.Rest.Requests.Users
{
    class GetUserRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetUserRequest(string login)
            : base(String.Format("/rest/admin/user/{0}", login))
        {
        }
    }
}
