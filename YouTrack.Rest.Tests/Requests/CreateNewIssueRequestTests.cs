using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class CreateNewIssueRequestTests : YouTrackRequestTests<CreateNewIssueRequest, IYouTrackPutRequest>
    {
        protected override CreateNewIssueRequest CreateSut()
        {
            return new CreateNewIssueRequest("FOO", "BAR", "Blah");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue?project=FOO&summary=BAR&description=Blah"; }
        }
    }
}
