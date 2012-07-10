using NUnit.Framework;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    [TestFixture]
    class GetUsersGroupsRequestTests : YouTrackRequestTests<GetUsersGroupsRequest, IYouTrackGetRequest>
    {
        protected override GetUsersGroupsRequest CreateSut()
        {
            return new GetUsersGroupsRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/user/foobar/group"; }
        }
    }
}
