using System;
using System.Linq;
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
            SetIssueProxy(StepHelper.CreateIssue("SB", "Testing Fetching", "I can be fetched"));
        }


        [When(@"I request the issue")]
        public void WhenIRequestTheIssue()
        {
            string issueId = GetIssueProxy().Id;

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

            Assert.That(issue.CommentsCount, Is.EqualTo(0));
            Assert.That(issue.Created, Is.GreaterThan(DateTime.MinValue));
            Assert.That(issue.Description, Is.EqualTo("I can be fetched"));
            Assert.That(issue.NumberInProject, Is.GreaterThan(0));
            Assert.That(issue.Priority, Is.EqualTo("Normal")); //Default value for the Sandbox
            Assert.That(issue.ProjectShortName, Is.EqualTo("SB")); //Sandbox Project
            Assert.That(issue.ReporterName, Is.EqualTo("youtrackapi"));
            Assert.That(issue.State, Is.EqualTo("Submitted")); //Default value for the Sandbox
            Assert.That(issue.Type, Is.EqualTo("Bug")); //Default value for the Sandbox
            Assert.That(issue.Updated, Is.GreaterThan(DateTime.MinValue));
            Assert.That(issue.UpdaterName, Is.EqualTo("youtrackapi"));
            Assert.That(issue.VotesCount, Is.EqualTo(0));
        }

        [Given(@"I have given it a comment")]
        public void GivenIHaveGivenItAComment()
        {
            GetIssueProxy().AddComment("blah blah");
        }

        [Then(@"it has the comment set")]
        public void ThenItHasTheCommentSet()
        {
            IIssue issue = ScenarioContext.Current.Get<IIssue>();

            Assert.That(issue.Comments.Single().Text, Is.EqualTo("blah blah"));
        }

    }
}
