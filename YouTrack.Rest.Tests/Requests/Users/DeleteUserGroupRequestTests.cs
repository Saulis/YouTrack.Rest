using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class DeleteUserGroupRequestTests : YouTrackRequestTests<DeleteUserGroupRequest, IYouTrackDeleteRequest>
    {
        protected override DeleteUserGroupRequest CreateSut()
        {
            return new DeleteUserGroupRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/group/foobar"; }
        }
    }
}
