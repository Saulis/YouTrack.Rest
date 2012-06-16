using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class LoginRequestTests : YouTrackRequestTests<LoginRequest>
    {
        protected override LoginRequest CreateSut()
        {
            return new LoginRequest("foo", "bar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/user/login?login=foo&password=bar"; }
        }
    }
}