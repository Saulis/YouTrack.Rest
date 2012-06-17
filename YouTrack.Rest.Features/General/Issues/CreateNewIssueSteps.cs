using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Create New Issue")]
    public class CreateNewIssueSteps : Steps.Steps
    {
        [AfterScenario]
        public void Teardown()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            if(StepHelper.IssueExists(issueId))
            {
                StepHelper.DeleteIssue(issueId);
            }
        }

        [When(@"I create a new issue to a project with summary and description")]
        public void WhenICreateANewIssueToAProjectWithSummaryAndDescription()
        {
            string issueId = StepHelper.CreateIssue("SB", "Testing", "1-2-3");

            ScenarioContext.Current.Set(issueId, "issueId");
        }

        [Then(@"an issue is created")]
        public void ThenAnIssueIsCreated()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            Assert.That(issueId, Is.Not.Null);
            Assert.That(issueId, Is.StringContaining("SB-"));
        }

        [When(@"I create a new issue to a project with permitted group")]
        public void WhenICreateANewIssueToAProjectWithPermittedGroup()
        {
            IIssue issue = StepHelper.CreateAndGetIssue("SB", "Testing", "1-2-3", permittedGroup: "myGroup");

            ScenarioContext.Current.Set(issue, "issue");
        }

        [Then(@"an issue is created with group permissions")]
        public void ThenAnIssueIsCreatedWithGroupPermissions()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I create a new issue to a project with attachments")]
        public void WhenICreateANewIssueToAProjectWithAttachments()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"an issue is created with attachments")]
        public void ThenAnIssueIsCreatedWithAttachments()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
