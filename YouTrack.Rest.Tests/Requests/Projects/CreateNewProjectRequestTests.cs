using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Projects;

namespace YouTrack.Rest.Tests.Requests.Projects
{
    class CreateNewProjectRequestTests : YouTrackRequestTests<CreateNewProjectRequest, IYouTrackPutRequest>
    {
        protected override CreateNewProjectRequest CreateSut()
        {
            return new CreateNewProjectRequest("foo", "bar", "mr.foo", 2, "desc");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/project/foo?projectName=bar&projectLeadLogin=mr.foo&startingNumber=2&description=desc"; }
        }
    }
}
