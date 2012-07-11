using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
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
