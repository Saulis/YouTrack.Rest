using System;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    public class IssueSteps : Steps.Steps
    {
        [AfterScenario]
        public void Teardown()
        {
            Console.WriteLine("Tearing down the Scenario...");

            string issueId = ScenarioContext.Current.Get<string>("issueId");

            if (StepHelper.IssueExists(issueId))
            {
                StepHelper.DeleteIssue(issueId);
            }
        }

        protected void SetIssueId(string issueId)
        {
            ScenarioContext.Current.Set(issueId, "issueId");
        }

        protected string GetIssueId()
        {
            return ScenarioContext.Current.Get<string>("issueId");
        }
    }
}