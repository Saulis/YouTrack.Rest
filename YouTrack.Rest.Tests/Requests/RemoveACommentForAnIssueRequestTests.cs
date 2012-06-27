using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class RemoveACommentForAnIssueRequestTests : YouTrackRequestTests<RemoveACommentForAnIssueRequest, IYouTrackDeleteRequest>
    {
        protected override RemoveACommentForAnIssueRequest CreateSut()
        {
            return new RemoveACommentForAnIssueRequest("foo", "bar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/foo/comment/bar"; }
        }
    }
}
