using System;

namespace YouTrack.Rest.Requests.Projects
{
    class GetProjectSubsystemsRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetProjectSubsystemsRequest(string projectId) : base(String.Format("/rest/admin/project/{0}/subsystem/", projectId))
        {
        }
    }
}
