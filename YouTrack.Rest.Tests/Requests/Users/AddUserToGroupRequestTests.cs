using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class AddUserToGroupRequestTests : YouTrackRequestTests<AddUserToGroupRequest, IYouTrackPostRequest>
    {
        protected override AddUserToGroupRequest CreateSut()
        {
            return new AddUserToGroupRequest("foo", "bar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/user/foo/group/bar"; }
        }
    }
}
