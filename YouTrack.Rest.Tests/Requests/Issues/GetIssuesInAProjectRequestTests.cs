using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
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
