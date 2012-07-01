using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Delete User")]
    public class DeleteUserSteps : UserSteps
    {
        [Given(@"I have create a user")]
        public void GivenIHaveCreateAUser()
        {
            CreateUser("foobar", "password", "email");
        }

        [When(@"I delete the user")]
        public void WhenIDeleteTheUser()
        {
            DeleteUser("foobar");
        }

        [Then(@"the user is deleted")]
        public void ThenTheUserIsDeleted()
        {
            Assert.IsFalse(UserExists("foobar"));
        }

    }
}
