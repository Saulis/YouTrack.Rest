using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Get user roles")]
    public class GetUserRolesSteps : UserSteps
    {
        [Given(@"I have created an user")]
        public void GivenIHaveCreatedAnUser()
        {
            CreateUser("foo", "bar", "email@email.com");
        }

        [When(@"I fetch the user")]
        public void WhenIFetchTheUser()
        {
            IUser user = GetSavedUser();

            Console.WriteLine(user.FullName);
        }


        [Then(@"the user should have roles")]
        public void ThenTheUserShouldHaveRoles()
        {
            IUser user = GetSavedUser();

            Assert.That(user.Roles, Is.Not.Empty);
            Assert.That(user.Roles.Select(r => r.Name), Contains.Item("Observer"));
        }
    }
}
