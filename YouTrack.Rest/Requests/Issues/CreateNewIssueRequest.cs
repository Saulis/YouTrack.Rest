namespace YouTrack.Rest.Requests.Issues
{
    class CreateNewIssueRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public CreateNewIssueRequest(string project, string summary, string description, string group = null) : base("/rest/issue")
        {
            ResourceBuilder.AddParameter("project", project);
            ResourceBuilder.AddParameter("summary", summary);
            ResourceBuilder.AddParameter("description", description);
            ResourceBuilder.AddParameter("permittedGroup", group);
        }
    }
}