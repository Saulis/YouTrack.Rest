using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace YouTrack.Rest.Features.Administration.Users
{
    [Binding]
    [Scope(Feature = "Get User (admin)")]
    public class GetUserSteps : UserSteps
    {
        [Given(@"I have added an user")]
        public void GivenIHaveAddedAnUser()
        {
            CreateUser("foo", "password", "email@com.com", "Mr. Fullname");
        }

        [When(@"I fetch the user")]
        public void WhenIFetchTheUser()
        {
            IUser user = GetUser("foo");

            ScenarioContext.Current.Set(user);
        }

        [Then(@"user is fetched")]
        public void ThenUserIsFetched()
        {
            IUser user = ScenarioContext.Current.Get<IUser>();

            Assert.That(user.Login, Is.EqualTo("foo"));
            Assert.That(user.Email, Is.EqualTo("email@com.com"));
            Assert.That(user.FullName, Is.EqualTo("Mr. Fullname"));
        }

    }
}
