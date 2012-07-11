using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
{
    class SetTypeOfAnIssueRequestTests : YouTrackRequestTests<SetTypeOfAnIssueRequest, IYouTrackPostRequest>
    {
        protected override SetTypeOfAnIssueRequest CreateSut()
        {
            return new SetTypeOfAnIssueRequest("FOO-BAR", "Task");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/execute?command=Type%20Task"; }
        }
    }
}
