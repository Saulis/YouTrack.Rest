using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
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
