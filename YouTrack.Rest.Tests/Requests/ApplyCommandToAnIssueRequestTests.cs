using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
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
