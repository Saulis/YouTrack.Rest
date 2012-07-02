using System;

namespace YouTrack.Rest.Requests.Projects
{
    class GetProjectRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetProjectRequest(string projectId)
            : base(String.Format("/rest/admin/project/{0}", projectId))
        {
        }
    }
}
