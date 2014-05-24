using System;
using System.Globalization;

namespace YouTrack.Rest.Requests.Issues
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

        public GetIssuesInAProjectRequest(string project, string filter, int index, int size)
            : this(project, filter)
        {
            ResourceBuilder.AddParameter("after", index.ToString(CultureInfo.InvariantCulture));
            ResourceBuilder.AddParameter("max", size.ToString(CultureInfo.InvariantCulture));
        }
    }
}