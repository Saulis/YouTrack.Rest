using System;

namespace YouTrack.Rest.Requests
{
    internal class GetIssuesInAProjectRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetIssuesInAProjectRequest(string project)
            : base(String.Format("/rest/issue/byproject/{0}", project))
        {
        }

        public GetIssuesInAProjectRequest(string project, string filter) : this(project)
        {
            ResourceBuilder.AddParameter("filter", filter);
        }
    }
}