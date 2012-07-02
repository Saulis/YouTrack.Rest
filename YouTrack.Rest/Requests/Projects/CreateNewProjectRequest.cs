using System;

namespace YouTrack.Rest.Requests.Projects
{
    class CreateNewProjectRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public CreateNewProjectRequest(string projectId, string projectName, string projectLeadLogin, int startingNumber = 1, string description = null)
            : base(String.Format("/rest/admin/project/{0}", projectId))
        {
            ResourceBuilder.AddParameter("projectName", projectName);
            ResourceBuilder.AddParameter("projectLeadLogin", projectLeadLogin);
            ResourceBuilder.AddParameter("startingNumber", startingNumber.ToString());
            ResourceBuilder.AddParameter("description", description);
        }
    }
}
