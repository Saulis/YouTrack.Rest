using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class CreateUserGroupRequestTests : YouTrackRequestTests<CreateUserGroupRequest, IYouTrackPutRequest>
    {
        protected override CreateUserGroupRequest CreateSut()
        {
            return new CreateUserGroupRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/group/foobar"; }
        }
    }
}
