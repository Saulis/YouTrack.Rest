using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.General.Issues
{
    [Binding]
    [Scope(Feature = "Attach File to an Issue")]
    public class AttachFileToAnIssueSteps : IssueSteps
    {
        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SetIssueId(StepHelper.CreateIssue("SB", "Testing attachments", "Blah"));
        }

        [When(@"I attach an file to the issue")]
        public void WhenIAttachAnFileToTheIssue()
        {
            StepHelper.AttachFile(GetIssueId(), @"Steps\Attachments\I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production.jpg");
        }

        [Then(@"the file is attached")]
        public void ThenTheFileIsAttached()
        {
            IIssueProxy issue = StepHelper.GetIssueProxy(GetIssueId());

            IEnumerable<IAttachment> attachments = issue.GetAttachments();

            Assert.That(attachments.Count(), Is.EqualTo(1));
            
            IAttachment attachment = attachments.Single();
            Assert.That(attachment.Name, Is.EqualTo("I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production1.jpg"));
            Assert.That(attachment.AuthorLogin, Is.EqualTo("youtrackapi"));
            Assert.That(attachment.Group, Is.EqualTo("All Users"));
        }

    }
}
