using System;
using System.Collections.Generic;
using System.IO;
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
        private string expectedFileName;

        [Given(@"I have created an issue")]
        public void GivenIHaveCreatedAnIssue()
        {
            SetIssueProxy(StepHelper.CreateIssue("SB", "Testing attachments", "Blah"));
        }

        [When(@"I attach an file to the issue using a path")]
        public void WhenIAttachAnFileToTheIssue()
        {
            StepHelper.AttachFile(GetIssueProxy(), @"Steps\Attachments\I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production.jpg");

            expectedFileName = "I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production1.jpg";
        }

        [When(@"I attach an file to the issue using bytes")]
        public void WhenIAttachAnFileToTheIssueUsingBytes()
        {
            StepHelper.AttachFile(GetIssueProxy(), File.ReadAllBytes(@"Steps\Attachments\I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production.jpg"), "I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production.jpg");

            //Extra .jpg is added to the attachment name.. in RestSharp or YouTrack... don't know why.
            expectedFileName = "I-don't-usually-test-my-code-But-when-I-do-it,-I-do-it-in-production.jpg1.jpg";
        }


        [Then(@"the file is attached")]
        public void ThenTheFileIsAttached()
        {
            IIssueProxy issue = GetIssueProxy();

            IEnumerable<IAttachment> attachments = issue.GetAttachments();

            Assert.That(attachments.Count(), Is.EqualTo(1));
            
            IAttachment attachment = attachments.Single();
            Assert.That(attachment.Name, Is.EqualTo(expectedFileName));
            Assert.That(attachment.AuthorLogin, Is.EqualTo("youtrackapi"));
            Assert.That(attachment.Group, Is.EqualTo("All Users"));
        }

    }
}
