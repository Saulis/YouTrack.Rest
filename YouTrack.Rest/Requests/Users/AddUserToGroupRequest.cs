namespace YouTrack.Rest.Requests.Users
{
    class AddUserToGroupRequest : YouTrackRequest, IYouTrackPostRequest
    {
        public AddUserToGroupRequest(string login, string groupName)
            : base(string.Format("/rest/admin/user/{0}/group/{1}", login, groupName))
        {
        }
    }
}