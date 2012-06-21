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

            if (HasIssueProxy())
            {
                string issueId = GetIssueProxy().Id;

                if (StepHelper.IssueExists(issueId))
                {
                    StepHelper.DeleteIssue(issueId);
                }
            }
        }

        private bool HasIssueProxy()
        {
            return ScenarioContext.Current.ContainsKey("issueProxy");
        }

        protected void SetIssueProxy(IIssueProxy issue)
        {
            ScenarioContext.Current.Set(issue, "issueProxy");
        }

        protected IIssueProxy GetIssueProxy()
        {
            return ScenarioContext.Current.Get<IIssueProxy>("issueProxy");
        }
    }
}