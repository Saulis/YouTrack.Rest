using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class SetSubsystemOfAnIssueRequestTests : YouTrackRequestTests<SetSubsystemOfAnIssueRequest, IYouTrackPostRequest>
    {
        protected override SetSubsystemOfAnIssueRequest CreateSut()
        {
            return new SetSubsystemOfAnIssueRequest("FOO-BAR", "Super System");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/execute?command=Subsystem%20Super%20System"; }
        }
    }
}
