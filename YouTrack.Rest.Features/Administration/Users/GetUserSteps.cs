using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Get User (admin)")]
    public class GetUserSteps
    {
        [Given(@"I have added an user")]
        public void GivenIHaveAddedAnUser()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I fetch the user")]
        public void WhenIFetchTheUser()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user is fetched")]
        public void ThenUserIsFetched()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
