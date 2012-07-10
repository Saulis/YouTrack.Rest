using System;

namespace YouTrack.Rest.Requests.Users
{
    class GetUsersGroupsRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetUsersGroupsRequest(string login)
            : base(String.Format("/rest/admin/user/{0}/group", login))
        {
        }
    }
}
