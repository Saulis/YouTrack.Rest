using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Add user account to an group")]
    public class AddUserToGroupSteps : UserSteps
    {
        [Given("I have created a user")]
        public void GivenIHaveCreatedAUser()
        {
            CreateUser(TestSettings.Username, TestSettings.Password, TestSettings.BaseUrl);
        }

        [When("I add the user to admin group")]
        public void WhenIAddUserToAdminGroup()
        {
            IUser user = GetUser(GetSavedLogin());

            user.JoinGroup("Admin");
        }

        [Then("I add the user to admin group")]
        public void ThenUserBelongsToAdminGroup()
        {
            IUser user = GetUser(GetSavedLogin());

            Assert.That(user.Groups.Select(g => g.Name), Contains.Item("Admin"));
        }
    }
}
