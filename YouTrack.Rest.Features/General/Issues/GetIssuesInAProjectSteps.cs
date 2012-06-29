using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Get Issues in a project")]
    public class GetIssuesInAProjectSteps : IssueSteps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SaveIssue(StepHelper.CreateIssue("SB", "Testing search", "blah blah"));
        }

        [When(@"I search for the issue with summary filter")]
        public void WhenISearchForTheIssueWithSummaryFilter()
        {
            IEnumerable<IIssue> issues = StepHelper.GetIssues("SB", "Testing search");

            ScenarioContext.Current.Set(issues);
        }

        [When(@"I search all the issues of the project")]
        public void WhenISearchAllTheIssuesOfTheProject()
        {
            IEnumerable<IIssue> issues = StepHelper.GetIssues("SB");

            ScenarioContext.Current.Set(issues);
        }

        [Then(@"I receive the issue")]
        public void ThenIReceiveTheIssue()
        {
            IEnumerable<IIssue> issues = ScenarioContext.Current.Get<IEnumerable<IIssue>>();

            Assert.That(issues, Is.Not.Empty);
        }
    }
}
