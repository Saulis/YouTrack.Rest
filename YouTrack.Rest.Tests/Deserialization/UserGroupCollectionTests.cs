using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;

namespace YouTrack.Rest.Tests.Deserialization
{
    class UserGroupCollectionTests : TestFor<UserGroupCollection>
    {
        private Rest.Deserialization.UserGroup deserializedUserGroup;
        private IConnection connection;

        protected override void SetupDependencies()
        {
            connection = Mock<IConnection>();

            Sut.UserGroups = new List<Rest.Deserialization.UserGroup>();
            deserializedUserGroup = Mock<Rest.Deserialization.UserGroup>();
            Sut.UserGroups.Add(deserializedUserGroup);
        }

        [Test]
        public void InnerUserGroupsAreUsed()
        {
            //ToList() will force enumeration and execution
            Sut.GetUserGroups(connection).ToList();

            deserializedUserGroup.Received().GetUserGroup(connection);
        }
    }
}
