using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class AddCommentToIssueRequestTests :  YouTrackRequestTests<AddCommentToIssueRequest>
    {
        protected override AddCommentToIssueRequest CreateSut()
        {
            return new AddCommentToIssueRequest("FOO-BAR", "foobar!");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/execute?comment=foobar!"; }
        }
    }
}
