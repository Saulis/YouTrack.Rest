using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrack.Rest.Requests.Users
{
    class CreateANewUserRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public CreateANewUserRequest(string login, string password, string email, string fullName = null)
            : base(String.Format("/rest/admin/user/{0}", login))
        {
            ResourceBuilder.AddParameter("password", password);
            ResourceBuilder.AddParameter("email", email);
            ResourceBuilder.AddParameter("fullName", fullName);
        }
    }
}
