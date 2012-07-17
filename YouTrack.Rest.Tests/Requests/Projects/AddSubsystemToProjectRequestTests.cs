using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests.Requests.Projects
{
    class AddSubsystemToProjectRequestTests : YouTrackRequestTests<AddSubsystemToProjectRequest, IYouTrackPutRequest>
    {
        protected override AddSubsystemToProjectRequest CreateSut()
        {
            return new AddSubsystemToProjectRequest("FOOBAR", "foo");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/project/FOOBAR/subsystem/foo"; }
        }
    }
}
