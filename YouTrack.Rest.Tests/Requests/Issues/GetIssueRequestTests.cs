using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class GetIssueRequestTests : YouTrackRequestTests<GetIssueRequest, IYouTrackGetRequest>
    {
        protected override GetIssueRequest CreateSut()
        {
            return new GetIssueRequest("FOO-123");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-123"; }
        }
    }
}
