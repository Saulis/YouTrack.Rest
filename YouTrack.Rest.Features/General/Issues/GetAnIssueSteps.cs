using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Get an Issue")]
    public class GetAnIssueSteps : IssueSteps
    {
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
            
        }

        [Then(@"it has the default fields set")]
        public void ThenItHasTheDefaultFieldsSet()
        {
            IIssue issue = ScenarioContext.Current.Get<IIssue>();

            Assert.That(issue.ProjectShortName, Is.EqualTo("SB")); //Sandbox Project
            Assert.That(issue.Type, Is.EqualTo("Bug")); //Default value for Sandbox Project
            Assert.That(issue.Summary, Is.EqualTo("Testing Fetching"));
        }

    }
}
