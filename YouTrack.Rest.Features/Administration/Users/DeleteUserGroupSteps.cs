using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Delete user group")]
    public class DeleteUserGroupSteps : UserSteps
    {
        [Given(@"I have created an user group")]
        public void GivenIHaveCreatedAnUserGroup()
        {
            CreateUserGroup("Foobar");
        }

        [When(@"I delete the user group")]
        public void WhenIDeleteTheUserGroup()
        {
            DeleteUserGroup("Foobar");
        }

        [Then(@"the user group is deleted")]
        public void ThenTheUserGroupIsDeleted()
        {
            IEnumerable<IUserGroup> usersGroups = GetAllUserGroups();

            CollectionAssert.DoesNotContain(usersGroups.Select(ug => ug.Name), "Foobar");
        }
    }
}
