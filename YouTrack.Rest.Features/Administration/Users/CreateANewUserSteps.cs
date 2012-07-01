using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Create a new user")]
    public class CreateANewUserSteps : UserSteps
    {
        [When(@"I create a new user")]
        public void WhenICreateANewUser()
        {
            CreateUser("foo", "Mr. Fullname", "email@com.com", "password");
        }

        [Then(@"the user is created")]
        public void ThenTheUserIsCreated()
        {
            //No exceptions, hurray!
        }
    }

    public class UserSteps : Steps.Steps
    {
        protected void CreateUser(string login, string fullname, string email, string password)
        {
            StepHelper.CreateUser(login, fullname, email, password);
        }

    }
}
