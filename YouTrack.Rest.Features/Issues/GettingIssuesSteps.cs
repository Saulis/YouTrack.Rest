using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Issues
{
    [Binding]
    [Scope(Feature = "Getting Issues")]
    public class GettingIssuesSteps : Steps.Steps
    {
        [AfterScenario]
        public void Teardown()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            if (StepHelper.IssueExists(issueId))
            {
                StepHelper.DeleteIssue(issueId);
            }
        }


        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            string issueId = StepHelper.CreateIssue("SB", "Testing Fetching", "I can be fetched");

            ScenarioContext.Current.Set(issueId, "issueId");
        }


        [When(@"I request the issue")]
        public void WhenIRequestTheIssue()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            IIssue issue = StepHelper.GetIssue(issueId);

            ScenarioContext.Current.Set(issue);
        }

        [Then(@"the issue is returned")]
        public void ThenTheIssueIsReturned()
        {
            IIssue issue = ScenarioContext.Current.Get<IIssue>();

            Assert.That(issue, Is.Not.Null);
            Assert.That(issue.ProjectShortName, Is.EqualTo("SB")); //Sandbox Project
            Assert.That(issue.Type, Is.EqualTo("Bug")); //Default value for Sandbox Project
            Assert.That(issue.Summary, Is.EqualTo("Testing Fetching"));
        }
    }
}
