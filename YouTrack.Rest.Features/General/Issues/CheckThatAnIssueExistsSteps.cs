using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Check that an Issue Exists")]
    public class CheckThatAnIssueExistsSteps : IssueSteps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            string issueId = StepHelper.CreateIssue("SB", "Testing Exists", "I exist");

            ScenarioContext.Current.Set(issueId, "issueId");
        }

        [Given(@"I haven't created an issue")]
        public void GivenIHavenTCreatedAnIssue()
        {
            ScenarioContext.Current.Set("FOOBAR-123", "issueId");
        }

        [When(@"I check if the issue exists")]
        public void WhenICheckIfTheIssueExists()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            ScenarioContext.Current.Set(StepHelper.IssueExists(issueId));
        }

        [Then(@"I am told it does exist")]
        public void ThenIAmToldItDoesExist()
        {
            Assert.IsTrue(ScenarioContext.Current.Get<bool>());
        }

        [Then(@"I am told it does not exist")]
        public void ThenIAmToldItDoesNotExist()
        {
            Assert.IsFalse(ScenarioContext.Current.Get<bool>());
        }

    }
}
