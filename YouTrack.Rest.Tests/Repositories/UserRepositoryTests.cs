using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Repositories;
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
        public void ConnectionIsCalledOnCreateUser()
        {
            Sut.CreateUser("login", "password", "email", "fullName");

            connection.Received().Put(Arg.Any<CreateANewUserRequest>());
        }
    }
}
