using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class GetAttachmentsOfAnIssueRequestTests : YouTrackRequestTests<GetAttachmentsOfAnIssueRequest, IYouTrackGetRequest>
    {
        protected override GetAttachmentsOfAnIssueRequest CreateSut()
        {
            return new GetAttachmentsOfAnIssueRequest("FOO-BAR");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/attachment"; }
        }
    }
}
