using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class GetCommentsOfAnIssueRequestTests : YouTrackRequestTests<GetCommentsOfAnIssueRequest, IYouTrackGetRequest>
    {
        protected override GetCommentsOfAnIssueRequest CreateSut()
        {
            return new GetCommentsOfAnIssueRequest("FOO-BAR");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/comment"; }
        }
    }
}
