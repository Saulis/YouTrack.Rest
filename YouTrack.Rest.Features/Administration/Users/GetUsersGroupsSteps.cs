using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Get all groups the specified user participates in")]
    public class GetUsersGroupsSteps : UserSteps
    {
       [Given("I have created a user")]
       public void GivenIHaveCreatedAUser()
       {
           CreateUser("foo", "bar", "email");
       }

       [When("I fetch the users groups")]
       public void WhenIFetchTheUsersGroups()
       {
           IUser user = GetUser(GetSavedLogin());
           IEnumerable<IUserGroup> userGroups = user.Groups;

           ScenarioContext.Current.Set(userGroups);
       }

        [Then("the user belongs to new users group")]
        public void ThenUserBelongsToNewUsersGroup()
        {
            IEnumerable<IUserGroup> userGroups = ScenarioContext.Current.Get<IEnumerable<IUserGroup>>();

            Assert.Contains("New Users", userGroups.Select(g => g.Name).ToList());
        }
    }
}
