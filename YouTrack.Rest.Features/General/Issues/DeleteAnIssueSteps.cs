using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Delete an Issue")]
    public class DeleteAnIssueSteps : IssueSteps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SaveIssue(StepHelper.CreateIssue("SB", "Testing Deletion", "I can be deleted"));
        }

        [When(@"I delete the issue")]
        public void WhenIDeleteTheIssue()
        {
            StepHelper.DeleteIssue(GetSavedIssue().Id);
        }

        [Then(@"the issue is deleted")]
        public void ThenTheIssueIsDeleted()
        {
            Assert.IsFalse(StepHelper.IssueExists(GetSavedIssue().Id));
        }

    }
}
