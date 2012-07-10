using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests
{
    class UserActionsTests : TestFor<UserActions>
    {
        private IConnection connection;

        protected override UserActions CreateSut()
        {
            connection = Mock<IConnection>();

            return new UserActions("foobar", connection);
        }

        [Test]
        public void AddUserToGroupRequestIsUsed()
        {
            Sut.JoinGroup("foobar");

            connection.Received().Post(Arg.Any<AddUserToGroupRequest>());
        }

        [Test]
        public void GetUsersGroupsRequestIsUsed()
        {
            IEnumerable<IUserGroup> groups = Sut.Groups;
        }
    }
}
