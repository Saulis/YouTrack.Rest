using System;

namespace YouTrack.Rest.Requests.Issues
{
    class GetAttachmentsOfAnIssueRequest :  YouTrackRequest, IYouTrackGetRequest
    {
        public GetAttachmentsOfAnIssueRequest(string issueId) : base(String.Format("/rest/issue/{0}/attachment", issueId))
        {
        }
    }
}
