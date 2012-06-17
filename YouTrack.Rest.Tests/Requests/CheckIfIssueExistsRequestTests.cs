using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class CheckIfIssueExistsRequestTests : YouTrackRequestTests<CheckIfIssueExistsRequest>
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
