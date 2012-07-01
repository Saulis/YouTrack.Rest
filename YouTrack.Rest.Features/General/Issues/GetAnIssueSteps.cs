using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Get an Issue")]
    public class GetAnIssueSteps : IssueSteps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SaveIssue(StepHelper.CreateIssue("SB", "Testing Fetching", "I can be fetched"));
        }

        [Given(@"I have created an issue without description")]
        public void GivenIHaveCreatedAnIssueWithoutDescription()
        {
            SaveIssue(StepHelper.CreateIssue("SB", "Testing Fetching Without Description", ""));
        }

        [When(@"I request the issue")]
        public void WhenIRequestTheIssue()
        {
            //Using property getter will trigger fetching.
            string description = GetSavedIssue().Description;
        }

        [Then(@"the issue is returned")]
        public void ThenTheIssueIsReturned()
        {
            IIssue issue = GetSavedIssue();

            Assert.That(issue, Is.Not.Null);
        }

        [Then(@"it has the default fields set")]
        public void ThenItHasTheDefaultFieldsSet()
        {
            IIssue issue = GetSavedIssue();

            Assert.That(issue.CommentsCount, Is.EqualTo(0));
            Assert.That(issue.Created, Is.GreaterThan(DateTime.MinValue));
            Assert.That(issue.Description, Is.EqualTo("I can be fetched"));
            Assert.That(issue.NumberInProject, Is.GreaterThan(0));
            Assert.That(issue.Priority, Is.EqualTo("Normal")); //Default value for the Sandbox
            Assert.That(issue.ProjectShortName, Is.EqualTo("SB")); //Sandbox Project
            Assert.That(issue.ReporterName, Is.EqualTo(TestSettings.Username));
            Assert.That(issue.State, Is.EqualTo("Submitted")); //Default value for the Sandbox
            Assert.That(issue.Type, Is.EqualTo("Bug")); //Default value for the Sandbox
            Assert.That(issue.Updated, Is.GreaterThan(DateTime.MinValue));
            Assert.That(issue.UpdaterName, Is.EqualTo(TestSettings.Username));
            Assert.That(issue.VotesCount, Is.EqualTo(0));
        }

        [Then(@"it has the description set to an empty string")]
        public void ThenItHasTheDescriptionSetToAnEmptyString()
        {
            IIssue issue = GetSavedIssue();

            Assert.That(issue.Description, Is.EqualTo(""));
        }

        [Given(@"I have given it a comment")]
        public void GivenIHaveGivenItAComment()
        {
            GetSavedIssue().AddComment("blah blah");
        }

        [Then(@"it has the comment set")]
        public void ThenItHasTheCommentSet()
        {
            IIssue issue = GetSavedIssue();

            Assert.That(issue.Comments.Single().Text, Is.EqualTo("blah blah"));
        }

    }
}
