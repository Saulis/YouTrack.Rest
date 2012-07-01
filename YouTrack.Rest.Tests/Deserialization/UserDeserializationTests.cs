using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace YouTrack.Rest.Tests.Deserialization
{
    class UserDeserializationTests : TestFor<Rest.Deserialization.User>
    {
        private IConnection connection;

        private const string Login = "login";
        private const string FullName = "Mr.Fullname";
        private const string Email = "foo@bar.com";

        protected override void SetupDependencies()
        {
            connection = Mock<IConnection>();
            Sut.Login = Login;
            Sut.FullName = FullName;
            Sut.Email = Email;
        }

        [Test]
        public void UserIsReturned()
        {
            IUser user = Sut.GetUser();

            Assert.That(user, Is.TypeOf<User>());
        }

        [Test]
        public void LoginIsAssigned()
        {
            IUser user = Sut.GetUser();

            Assert.That(user.Login, Is.EqualTo(Login));
        }

        [Test]
        public void FullNameIsAssigned()
        {
            IUser user = Sut.GetUser();

            Assert.That(user.FullName, Is.EqualTo(FullName));
        }

        [Test]
        public void EmailIsAssigned()
        {
            IUser user = Sut.GetUser();

            Assert.That(user.Email, Is.EqualTo(Email));
        }
    }
}
