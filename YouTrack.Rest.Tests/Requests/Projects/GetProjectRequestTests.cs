using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests.Requests.Projects
{
    class GetProjectRequestTests : YouTrackRequestTests<GetProjectRequest, IYouTrackGetRequest>
    {
        protected override GetProjectRequest CreateSut()
        {
            return new GetProjectRequest("foobar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/project/foobar"; }
        }
    }
}
