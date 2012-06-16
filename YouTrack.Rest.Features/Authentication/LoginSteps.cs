using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Features.Authentication
{
    [Binding]
    public class LoginSteps : Steps.Steps
    {
        [When(@"I authenticate with login ""(.*)"" and password ""(.*)"" to ""(.*)""")]
        public void WhenIAuthenticateWith(string login, string password, string baseUrl)
        {
            StepHelper.InitializeYouTrackClient(baseUrl, login, password);

            try
            {
                StepHelper.GetConnection().Login();
            }
            catch(RequestFailedException e)
            {
                Console.WriteLine("Exception catched: {0}", e);
            }
        }

        [Then(@"I am authenticated")]
        public void ThenIAmAuthenticated()
        {
            Assert.IsTrue(StepHelper.GetConnection().IsAuthenticated);
        }

        [Then(@"I am not authenticated")]
        public void ThenIAmNotAuthenticated()
        {
            Assert.IsFalse(StepHelper.GetConnection().IsAuthenticated);
        }

    }
}
