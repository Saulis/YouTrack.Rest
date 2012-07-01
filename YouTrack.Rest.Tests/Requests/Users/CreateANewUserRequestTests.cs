using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class CreateANewUserRequestTests : YouTrackRequestTests<CreateANewUserRequest, IYouTrackPutRequest>
    {
        protected override CreateANewUserRequest CreateSut()
        {
            return new CreateANewUserRequest("foo", "secretpassword", "foo@bar", "Mr.Fullname");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/user/foo?password=secretpassword&email=foo%40bar&fullName=Mr.Fullname"; }
        }
    }
}
