using System.IO;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Create New Issue")]
    public class CreateNewIssueSteps : IssueSteps
    {
        [When(@"I create a new issue to a project with summary and description")]
        public void WhenICreateANewIssueToAProjectWithSummaryAndDescription()
        {
            SetIssueProxy(StepHelper.CreateIssue("SB", "Testing", "1-2-3"));
        }

        [Then(@"an issue is created")]
        public void ThenAnIssueIsCreated()
        {
            string issueId = GetIssueProxy().Id;

            Assert.That(issueId, Is.Not.Null);
            Assert.That(issueId, Is.StringContaining("SB-"));
        }
    }
}
