using System;

namespace YouTrack.Rest.Requests.Users
{
    class GetUserRolesRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetUserRolesRequest(string login) : base(String.Format("/rest/admin/user/{0}/role", login))
        {
        }
    }
}
