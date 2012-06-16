using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    abstract class CreateNewIssueRequestTests : YouTrackRequestTests<CreateNewIssueRequest>
    {
        class WithProjectAndSummaryAndDescription : CreateNewIssueRequestTests
        {
            protected override string ExpectedRestResource
            {
                get { return "/rest/issue?project=foo&summary=bar&description=desc"; }
            }

            protected override CreateNewIssueRequest CreateSut()
            {
                return new CreateNewIssueRequest("foo", "bar", "desc");
            }
        }

        class WithProjectAndSummaryAndDescriptionAndPermittedGroup : CreateNewIssueRequestTests
        {
            protected override string ExpectedRestResource
            {
                get { return "/rest/issue?project=foo&summary=bar&description=desc&permittedGroup=group"; }
            }

            protected override CreateNewIssueRequest CreateSut()
            {
                return new CreateNewIssueRequest("foo", "bar", "desc", permittedGroup: "group");
            }
        }

        class WithProjectAndSummaryAndDescriptionAndAttachments : CreateNewIssueRequestTests
        {
            protected override string ExpectedRestResource
            {
                get { return "/rest/issue?project=foo&summary=bar&description=desc&attachments=xxx"; }
            }

            protected override CreateNewIssueRequest CreateSut()
            {
                return new CreateNewIssueRequest("foo", "bar", "desc", new byte[16]);
            }
        }
    }
}
