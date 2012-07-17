using NUnit.Framework;

namespace YouTrack.Rest.Tests.Deserialization
{
    class UserGroupDeserializationTests : TestFor<Rest.Deserialization.UserGroup>
    {
        private const string Name = "foobar";

        [Test]
        public void NameIsAssigned()
        {
            Sut.Name = Name;

            IUserGroup userGroup = Sut.GetUserGroup(Mock<IConnection>());

            Assert.That(userGroup.Name, Is.EqualTo(Name));
        }
    }
}
