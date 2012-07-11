using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class CheckIfIssueExistsRequestTests : YouTrackRequestTests<CheckIfIssueExistsRequest, IYouTrackGetRequest>
    {
        protected override CheckIfIssueExistsRequest CreateSut()
        {
            return new CheckIfIssueExistsRequest("FOO-BAR");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/exists"; }
        }
    }
}
