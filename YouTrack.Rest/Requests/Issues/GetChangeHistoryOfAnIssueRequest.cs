using System;

namespace YouTrack.Rest.Requests.Issues
{
    class GetChangeHistoryOfAnIssueRequest : YouTrackRequest, IYouTrackGetRequest
    {
        public GetChangeHistoryOfAnIssueRequest(string issueId)
            : base(String.Format("/rest/issue/{0}/changes", issueId))
        {
        }
    }
}