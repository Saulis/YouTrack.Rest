using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Get all user groups")]
    public class GetAllUserGroupsSteps : UserSteps
    {
        [When(@"I fetch all the user groups")]
        public void WhenIFetchAllTheUserGroups()
        {
            IEnumerable<IUserGroup> allUserGroups = GetAllUserGroups();

            ScenarioContext.Current.Set(allUserGroups);
        }

        [Then(@"I received user groups")]
        public void ThenIReceivedUserGroups()
        {
            IEnumerable<IUserGroup> userGroups = ScenarioContext.Current.Get<IEnumerable<IUserGroup>>();

            Assert.That(userGroups, Is.Not.Empty);
        }

    }
}
