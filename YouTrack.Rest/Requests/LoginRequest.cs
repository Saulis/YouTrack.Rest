namespace YouTrack.Rest.Requests
{
    class LoginRequest : YouTrackRequest, IYouTrackPostRequest
    {
        public LoginRequest(string login, string password) : base("/rest/user/login")
        {
            ResourceBuilder.AddParameter("login", login);
            ResourceBuilder.AddParameter("password", password);
        }
    }
}