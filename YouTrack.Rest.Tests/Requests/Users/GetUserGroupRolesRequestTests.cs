using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class GetUserGroupRolesRequestTests : YouTrackRequestTests<GetUserGroupRolesRequest, IYouTrackGetRequest>
    {
        protected override GetUserGroupRolesRequest CreateSut()
        {
            return new GetUserGroupRolesRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/group/foobar/role"; }
        }
    }
}
