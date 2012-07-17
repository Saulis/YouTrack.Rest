using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class GetAllUserGroupsRequestTests : YouTrackRequestTests<GetAllUserGroupsRequest, IYouTrackGetRequest>
    {
        protected override GetAllUserGroupsRequest CreateSut()
        {
            return new GetAllUserGroupsRequest();
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/group"; }
        }
    }
}
