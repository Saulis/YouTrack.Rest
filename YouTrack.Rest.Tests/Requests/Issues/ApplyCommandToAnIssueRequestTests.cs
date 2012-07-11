using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    abstract class ApplyCommandToAnIssueRequestTests : YouTrackRequestTests<ApplyCommandToAnIssueRequest, IYouTrackPostRequest>
    {
        private class AddComment : ApplyCommandToAnIssueRequestTests
        {
            protected override ApplyCommandToAnIssueRequest CreateSut()
            {
                return new ApplyCommandToAnIssueRequest("FOO-BAR", comment: "foobar!");
            }

            protected override string ExpectedRestResource
            {
                get { return "/rest/issue/FOO-BAR/execute?comment=foobar!"; }
            }
        }
    }
}
