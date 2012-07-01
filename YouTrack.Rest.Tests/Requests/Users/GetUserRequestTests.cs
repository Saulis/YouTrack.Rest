using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class GetUserRequestTests : YouTrackRequestTests<GetUserRequest, IYouTrackGetRequest>
    {
        protected override GetUserRequest CreateSut()
        {
            return new GetUserRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/user/foobar"; }
        }
    }
}
