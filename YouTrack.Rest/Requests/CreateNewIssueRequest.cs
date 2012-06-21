namespace YouTrack.Rest.Requests
{
    class CreateNewIssueRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public CreateNewIssueRequest(string project, string summary, string description) : base("/rest/issue")
        {
            ResourceBuilder.AddParameter("project", project);
            ResourceBuilder.AddParameter("summary", summary);
            ResourceBuilder.AddParameter("description", description);
        }
    }
}