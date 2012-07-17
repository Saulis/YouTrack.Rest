using System;

namespace YouTrack.Rest.Requests.Users
{
    class CreateUserGroupRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public CreateUserGroupRequest(string userGroupName)
            : base(String.Format("/rest/admin/group/{0}", userGroupName))
        {
        }
    }
}
