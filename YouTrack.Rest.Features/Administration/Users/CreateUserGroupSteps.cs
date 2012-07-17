using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Create user group")]
    public class CreateUserGroupSteps : UserSteps
    {
        private const string UserGroupName = "Foobar";

        [Given(@"I have created an user")]
        public void GivenIHaveCreatedAnUser()
        {
            CreateUser("foo", "bar", "email@email.com");
        }

        [When(@"I have created an user group")]
        public void WhenIHaveCreatedAnUserGroup()
        {
            CreateUserGroup(UserGroupName);
        }

        [When(@"I add the user to the group")]
        public void WhenIAddTheUserToTheGroup()
        {
            IUser user = GetSavedUser();    
            IUserGroup userGroup = GetSavedUserGroup();

            user.JoinGroup(userGroup.Name);
        }

        [Then(@"the user group is created")]
        public void ThenTheUserGroupIsCreated()
        {
            IUser user = GetSavedUser();

            Assert.That(user.Groups.Select(ug => ug.Name), Contains.Item(UserGroupName));
        }
    }
}
