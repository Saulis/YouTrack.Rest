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

            if (HasSavedIssue())
            {
                string issueId = GetSavedIssue().Id;

                if (StepHelper.IssueExists(issueId))
                {
                    StepHelper.DeleteIssue(issueId);
                }
            }
        }

        private bool HasSavedIssue()
        {
            return ScenarioContext.Current.ContainsKey("savedIssue");
        }

        protected void SaveIssue(IIssue issue)
        {
            ScenarioContext.Current.Set(issue, "savedIssue");
        }

        protected IIssue GetSavedIssue()
        {
            return ScenarioContext.Current.Get<IIssue>("savedIssue");
        }
    }
}