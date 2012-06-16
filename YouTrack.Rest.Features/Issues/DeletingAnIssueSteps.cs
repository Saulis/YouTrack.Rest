using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Issues
{
    [Binding]
    public class DeletingAnIssueSteps : Steps.Steps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            string issueId = StepHelper.CreateIssue("SB", "Testing Deletion", "I can be deleted");

            ScenarioContext.Current.Set(issueId, "issueId");
        }

        [When(@"I delete the issue")]
        public void WhenIDeleteTheIssue()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            StepHelper.DeleteIssue(issueId);
        }

        [Then(@"the issue is deleted")]
        public void ThenTheIssueIsDeleted()
        {
            string issueId = ScenarioContext.Current.Get<string>("issueId");

            Assert.IsFalse(StepHelper.IssueExists(issueId));
        }

    }
}
