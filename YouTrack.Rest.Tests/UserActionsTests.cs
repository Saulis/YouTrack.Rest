using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace YouTrack.Rest.Tests
{
    class UserActionsTests : TestFor<UserActions>
    {
        [Test]
        public void AddUserToGroupRequestIsUsed()
        {
            Sut.JoinGroup("foobar");
        }

        [Test]
        public void GetUsersGroupsRequestIsUsed()
        {
            var groups = Sut.Groups;
        }
    }
}
