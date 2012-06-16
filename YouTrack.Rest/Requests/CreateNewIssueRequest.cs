using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Requests
{
    class CreateNewIssueRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public CreateNewIssueRequest(string project, string summary, string description, byte[] attachments = null, string permittedGroup = null) : base("/rest/issue")
        {
            ResourceBuilder.AddParameter("project", project);
            ResourceBuilder.AddParameter("summary", summary);
            ResourceBuilder.AddParameter("description", description);
            ResourceBuilder.AddParameter("attachments", attachments);
            ResourceBuilder.AddParameter("permittedGroup", permittedGroup);
        }
    }
}