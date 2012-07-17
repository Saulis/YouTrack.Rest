using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Assign role to user group")]
    public class AssignRoleToUserGroupSteps : UserSteps
    {
        [Given("I have created an user")]
        public void GivenIHaveCreatedAnUser()
        {
            CreateUser("foo", "bar", "email@email.com");
        }

        [Given(@"I have created an user group")]
        public void GivenIHaveCreatedAnUserGroup()
        {
            CreateUserGroup("foogroup");
        }

        [When("I assign a role to the user group")]
        public void WhenIAssignARoleToTheUserGroup()
        {
            IUserGroup userGroup = GetSavedUserGroup();

            userGroup.AssignRole("Developer");
        }

        [Then(@"the role is assigned to the group")]
        public void ThenTheRoleIsAssignedToTheGroup()
        {
            IUserGroup userGroup = GetSavedUserGroup();

            IEnumerable<IUserRole> userRoles = userGroup.Roles;

            Assert.That(userRoles.Select(ur => ur.Name), Contains.Item("Developer"));
        }

        [When("I add the user to the group")]
        public void WhenIAddTheUserToTheGroup()
        {
            IUser user = GetSavedUser();
            IUserGroup userGroup = GetSavedUserGroup();

            user.JoinGroup(userGroup.Name);
        }

        [Then("the role is assigned to the user")]
        public void ThenTheRoleIsAssignedToTheUser()
        {
            IUser user = GetSavedUser();

            Assert.That(user.Roles.Select(r => r.Name), Contains.Item("Developer"));
        }
    }
}
