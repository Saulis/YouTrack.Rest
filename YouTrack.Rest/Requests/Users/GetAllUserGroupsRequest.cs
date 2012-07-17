namespace YouTrack.Rest.Requests.Users
{
    class GetAllUserGroupsRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetAllUserGroupsRequest()
            : base("/rest/admin/group")
        {
        }
    }
}
