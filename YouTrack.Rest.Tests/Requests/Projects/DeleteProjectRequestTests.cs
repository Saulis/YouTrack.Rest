using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests.Requests.Projects
{
    class DeleteProjectRequestTests : YouTrackRequestTests<DeleteProjectRequest, IYouTrackDeleteRequest>
    {
        protected override DeleteProjectRequest CreateSut()
        {
            return new DeleteProjectRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/project/foobar"; }
        }
    }
}
