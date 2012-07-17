using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Get user group roles")]
    public class GetUserGroupRolesSteps : UserSteps
    {
        [When(@"I fetch a user group")]
        public void WhenIFetchAUserGroup()
        {
            IEnumerable<IUserGroup> allUserGroups = GetAllUserGroups();

            ScenarioContext.Current.Set(allUserGroups);
        }

        [Then(@"the user group has roles")]
        public void ThenTheUserGroupHasRoles()
        {
            IEnumerable<IUserGroup> userGroups = ScenarioContext.Current.Get<IEnumerable<IUserGroup>>();
            IUserGroup userGroup = userGroups.First();

            Assert.That(userGroup.Roles, Is.Not.Empty);
        }
    }
}
