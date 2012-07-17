using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests.Requests.Projects
{
    class GetProjectSubsystemsRequestTests : YouTrackRequestTests<GetProjectSubsystemsRequest, IYouTrackGetRequest>
    {
        protected override GetProjectSubsystemsRequest CreateSut()
        {
            return new GetProjectSubsystemsRequest("FOOBAR");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/project/FOOBAR/subsystem/"; }
        }
    }
}
