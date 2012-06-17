using System;

namespace YouTrack.Rest.Requests
{
    class GetCommentsOfAnIssueRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetCommentsOfAnIssueRequest(string issueId)
            : base(String.Format("/rest/issue/{0}/comment", issueId))
        {
        }
    }
}