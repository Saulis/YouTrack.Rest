using System;

namespace YouTrack.Rest.Requests.Users
{
    class DeleteUserGroupRequest : YouTrackRequest, IYouTrackDeleteRequest
    {

        public DeleteUserGroupRequest(string userGroupName)
            : base(String.Format("/rest/admin/group/{0}", userGroupName))
        {
        }
    }
}
