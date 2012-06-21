using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
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
