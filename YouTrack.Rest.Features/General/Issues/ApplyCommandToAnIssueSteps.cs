using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Apply Command to an Issue")]
    public class ApplyCommandToAnIssueSteps : IssueSteps
    {
        private const string CommentText = "This is a comment";
        private const string CommentSummary = "Testing comments";
        private const string CommentDescription = "blah blah";
        private const string Subsystem = "Test";
        private const string IssueType = "Task";

        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SetIssueProxy(StepHelper.CreateIssue("SB", CommentSummary, CommentDescription));
        }

        [When(@"I add a comment to the issue")]
        public void WhenIAddACommentToTheIssue()
        {
            GetIssueProxy().AddComment(CommentText);
        }

        [Then(@"a comment is added to the issue")]
        public void ThenACommentIsAddedToTheIssue()
        {
            IEnumerable<IComment> comments = StepHelper.GetComments(GetIssueProxy());
            IComment comment = comments.Single();

            Assert.That(comment.Text, Is.EqualTo(CommentText));
        }

        [When(@"I change the Subsystem of the Issue")]
        public void WhenIChangeTheSubsystemOfTheIssue()
        {
            GetIssueProxy().SetSubsystem(Subsystem);
        }

        [Then(@"the Subsystem is changed")]
        public void ThenTheSubsystemIsChanged()
        {
            IIssueProxy issueProxy = GetIssueProxy();

            IIssue issue = StepHelper.GetIssue(issueProxy.Id);

            Assert.That(issue.Subsystem, Is.EqualTo(Subsystem));
        }

        [When(@"I change the Type of the Issue")]
        public void WhenIChangeTheTypeOfTheIssue()
        {
            GetIssueProxy().SetType(IssueType);
        }

        [Then(@"the Type is changed")]
        public void ThenTheTypeIsChanged()
        {
            IIssueProxy issueProxy = GetIssueProxy();

            IIssue issue = StepHelper.GetIssue(issueProxy.Id);

            Assert.That(issue.Type, Is.EqualTo(IssueType));
        }

    }
}
