using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Remove a comment for an issue")]
    public class RemoveACommentForAnIssueSteps : IssueSteps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SetIssueProxy(StepHelper.CreateIssue("SB", "Testing Comment removing", "blah blah"));
        }


        [Given(@"I have created an comment to the issue")]
        public void GivenIHaveCreatedAnCommentToTheIssue()
        {
            StepHelper.AddCommentToIssue(GetIssueProxy(), "comment");
        }

        [When(@"I remove the comment")]
        public void WhenIRemoveTheComment()
        {
            StepHelper.RemoveCommentForIssue(GetIssueProxy());

        }

        [Then(@"the comment is removed")]
        public void ThenTheCommentIsRemoved()
        {
            IIssueProxy issueProxy = GetIssueProxy();
            IEnumerable<IComment> comments = issueProxy.Comments;

            Assert.That(comments, Is.Empty);
        }

        [When(@"I try to remove a comment")]
        public void WhenITryToRemoveAComment()
        {
            try
            {
                GetIssueProxy().RemoveComment("FOOBAR");
            }
            catch (Exception e)
            {
                ScenarioContext.Current.Set(e);
            }
            
        }

        [Then(@"the comment is not found")]
        public void ThenTheCommentIsNotFound()
        {
            Exception exception = ScenarioContext.Current.Get<Exception>();

            Assert.That(exception, Is.TypeOf<RequestNotFoundException>());
        }
    }
}
