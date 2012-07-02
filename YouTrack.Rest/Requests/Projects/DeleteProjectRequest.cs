using System;

namespace YouTrack.Rest.Requests.Projects
{
    class DeleteProjectRequest : YouTrackRequest, IYouTrackDeleteRequest
    {
        public DeleteProjectRequest(string projectId)
            : base(String.Format("/rest/admin/project/{0}", projectId))
        {
        }
    }
}
