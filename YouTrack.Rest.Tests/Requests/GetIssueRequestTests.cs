using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class GetIssueRequestTests : YouTrackRequestTests<GetIssueRequest>
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
