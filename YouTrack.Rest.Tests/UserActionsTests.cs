using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;
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

        protected override void SetupDependencies()
        {
            UserGroupCollection userGroupCollection = CreateUserGroupCollection();
            connection.Get<UserGroupCollection>(Arg.Any<GetUsersGroupsRequest>()).Returns(userGroupCollection);
        }

        private static UserGroupCollection CreateUserGroupCollection()
        {
            UserGroupCollection userGroupCollection = new UserGroupCollection();
            userGroupCollection.UserGroups = new List<UserGroup>();

            return userGroupCollection;
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

            connection.Received().Get<UserGroupCollection>(Arg.Any<GetUsersGroupsRequest>());
        }

        [Test]
        public void GroupsAreCached()
        {
            IEnumerable<IUserGroup> userGroups = Sut.Groups;
            userGroups = Sut.Groups;

            connection.Received(1).Get<UserGroupCollection>(Arg.Any<GetUsersGroupsRequest>());
        }

        [Test]
        public void GroupsAreFetchedAfterJoiningGroup()
        {
            IEnumerable<IUserGroup> userGroups = Sut.Groups;
            Sut.JoinGroup("foobar");
            userGroups = Sut.Groups;

            connection.Received(2).Get<UserGroupCollection>(Arg.Any<GetUsersGroupsRequest>());
        }
    }
}
