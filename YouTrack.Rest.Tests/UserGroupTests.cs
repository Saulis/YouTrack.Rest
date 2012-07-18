using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests
{
    class UserGroupTests : TestFor<UserGroup>
    {
        private IConnection connection;

        protected override UserGroup CreateSut()
        {
            connection = Mock<IConnection>();
            return new UserGroup("foo", connection);
        }

        protected override void SetupDependencies()
        {
            UserRoleCollection userRoleCollection = Mock<UserRoleCollection>();
            userRoleCollection.UserRoles = new List<UserRole>();

            connection.Get<UserRoleCollection>(Arg.Any<GetUserGroupRolesRequest>()).Returns(userRoleCollection);
        }

        [Test]
        public void AssignRoleToUserGroupRequestIsUsed()
        {
            Sut.AssignRoleToAllProjects("foobar");

            connection.Received().Put(Arg.Any<AssignRoleToUserGroupRequest>());
        }

        [Test]
        public void GetUserGroupRolesRequestIsUsed()
        {
            IEnumerable<IUserRole> userRoles = Sut.Roles;

            connection.Received().Get<UserRoleCollection>(Arg.Any<GetUserGroupRolesRequest>());
        }

        [Test]
        public void UserRolesAreCached()
        {
            IEnumerable<IUserRole> userRoles = Sut.Roles;
            userRoles = Sut.Roles;

            connection.Received(1).Get<UserRoleCollection>(Arg.Any<GetUserGroupRolesRequest>());
        }
    }
}
