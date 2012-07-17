using System;

namespace YouTrack.Rest.Requests.Projects
{
    class AddSubsystemToProjectRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public AddSubsystemToProjectRequest(string projectId, string subsystemName)
            : base(String.Format("/rest/admin/project/{0}/subsystem/{1}", projectId, subsystemName))
        {
        }
    }
}
