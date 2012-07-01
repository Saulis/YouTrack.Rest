using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class DeleteUserRequestTests : YouTrackRequestTests<DeleteUserRequest, IYouTrackDeleteRequest>
    {
        protected override DeleteUserRequest CreateSut()
        {
            return new DeleteUserRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/user/foobar"; }
        }
    }
}
