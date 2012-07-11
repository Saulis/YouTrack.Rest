using System;
using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class ApplyCommandsToAnIssueRequestTests : YouTrackRequestTests<ApplyCommandsToAnIssueRequest, IYouTrackPostRequest>
    {
        protected override ApplyCommandsToAnIssueRequest CreateSut()
        {
            return new ApplyCommandsToAnIssueRequest("FOO-BAR", "foo", "bar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/execute?command=foo%20bar"; }
        }

        [Test]
        public void ExceptionThrownOnMissingCommands()
        {
            Assert.Throws<ArgumentNullException>(() => new ApplyCommandsToAnIssueRequest("FOO"));
        }
    }
}