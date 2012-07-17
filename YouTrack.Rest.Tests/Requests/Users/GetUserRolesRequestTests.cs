using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class GetUserRolesRequestTests : YouTrackRequestTests<GetUserRolesRequest, IYouTrackGetRequest>
    {
        protected override GetUserRolesRequest CreateSut()
        {
            return new GetUserRolesRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/user/foobar/role"; }
        }
    }
}
