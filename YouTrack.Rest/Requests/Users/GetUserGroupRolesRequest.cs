namespace YouTrack.Rest.Requests.Users
{
    class GetUserGroupRolesRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetUserGroupRolesRequest(string groupName)
            : base(string.Format("/rest/admin/group/{0}/role", groupName))
        {
        }
    }
}
