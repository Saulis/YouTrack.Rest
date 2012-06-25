using System;

namespace YouTrack.Rest.Requests
{
    internal class GetIssuesInAProjectRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetIssuesInAProjectRequest(string project, string filter) : base(String.Format("/rest/issue/byproject/{0}", project))
        {
            ResourceBuilder.AddParameter("filter", filter);
        }
    }
}