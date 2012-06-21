using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class DeleteIssueRequestTests : YouTrackRequestTests<DeleteIssueRequest, IYouTrackDeleteRequest>
    {
        protected override DeleteIssueRequest CreateSut()
        {
            return new DeleteIssueRequest("FOO-BAR");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR"; }
        }
    }
}
