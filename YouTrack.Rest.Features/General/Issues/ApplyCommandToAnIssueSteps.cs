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

    }
}
