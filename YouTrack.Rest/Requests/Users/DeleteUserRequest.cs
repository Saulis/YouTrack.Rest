using System;

namespace YouTrack.Rest.Requests.Users
{
    class DeleteUserRequest : YouTrackRequest, IYouTrackDeleteRequest
    {
        public DeleteUserRequest(string login)
            : base(String.Format("/rest/admin/user/{0}", login))
        {
            
        }
    }
}
