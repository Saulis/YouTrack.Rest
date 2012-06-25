using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class GetIssuesInAProjectRequestTests : YouTrackRequestTests<GetIssuesInAProjectRequest, IYouTrackGetRequest>
    {
        protected override GetIssuesInAProjectRequest CreateSut()
        {
            return new GetIssuesInAProjectRequest("FOO", "bar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/byproject/FOO?filter=bar"; }
        }
    }
}
