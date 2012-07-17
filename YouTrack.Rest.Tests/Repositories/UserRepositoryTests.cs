using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Repositories
{
    class UserRepositoryTests : TestFor<UserRepository>
    {
        private const string UserGroupName = "foobarGroup";
        private IConnection connection;

        protected override UserRepository CreateSut()
        {
            connection = Mock<IConnection>();

            return new UserRepository(connection);
        }

        [Test]
        public void CreateANewUserRequestIsUsed()
        {
            Sut.CreateUser("login", "password", "email", "fullName");

            connection.Received().Put(Arg.Any<CreateANewUserRequest>());
        }

        [Test]
        public void DeleteUserRequestIsUsed()
        {
            Sut.DeleteUser("login");

            connection.Received().Delete(Arg.Any<DeleteUserRequest>());
        }


        [Test]
        public void GetUserRequestIsUsed()
        {
            connection.Get<Rest.Deserialization.User>(Arg.Any<GetUserRequest>()).Returns(new Rest.Deserialization.User());

            Sut.GetUser("foobar");

            connection.Received().Get<Rest.Deserialization.User>(Arg.Any<GetUserRequest>());
        }

        [Test]
        public void UserExists()
        {
            Sut.UserExists("foobar");

            connection.Received().Get(Arg.Any<GetUserRequest>());
        }

        [Test]
        public void UserDoesNotExist()
        {
            connection.When(x => x.Get(Arg.Any<GetUserRequest>())).Do(x =>
                                                                          {
                                                                              throw new RequestNotFoundException(Mock<IRestResponse>());
                                                                          });

            Assert.IsFalse(Sut.UserExists("foo"));
        }

        [Test]
        public void CreateUserGroupRequestIsUsed()
        {
            Sut.CreateUserGroup(UserGroupName);

            connection.Put(Arg.Any<CreateUserGroupRequest>());
        }

        [Test]
        public void GetAllUserGroupsRequestIsUsed()
        {
            connection.Get<UserGroupCollection>(Arg.Any<GetAllUserGroupsRequest>()).Returns(Mock<UserGroupCollection>());

            Sut.GetUserGroups();

            connection.Get<UserGroupCollection>(Arg.Any<GetAllUserGroupsRequest>());
        }

        [Test]
        public void DeleteUserGroupRequestIsUsed()
        {
            Sut.DeleteUserGroup("foobar");

            connection.Delete(Arg.Any<DeleteUserGroupRequest>());
        }
    }
}
