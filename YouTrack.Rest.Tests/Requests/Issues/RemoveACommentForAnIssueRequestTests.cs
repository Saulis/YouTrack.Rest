using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
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
