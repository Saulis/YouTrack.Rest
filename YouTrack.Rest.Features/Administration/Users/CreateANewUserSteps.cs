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
            CreateUser("foo", "password", "email@com.com", "Mr. Fullname");
        }

        [Then(@"the user is created")]
        public void ThenTheUserIsCreated()
        {
            //No exceptions, hurray! //get user here and check fields
        }
    }
}
