using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Repositories
{
    class UserRepositoryTests : TestFor<UserRepository>
    {
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
    }
}
