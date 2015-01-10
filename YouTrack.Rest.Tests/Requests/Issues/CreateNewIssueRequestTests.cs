using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest.Tests.Requests.Issues
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

        class WithGroup : YouTrackRequestTests<CreateNewIssueRequest, IYouTrackPutRequest>
        {
            protected override CreateNewIssueRequest CreateSut()
            {
                return new CreateNewIssueRequest("FOO", "BAR", "Blah", "group");
            }

            protected override string ExpectedRestResource
            {
                get { return "/rest/issue?project=FOO&summary=BAR&description=Blah&permittedGroup=group"; }
            }
        }
    }
}
