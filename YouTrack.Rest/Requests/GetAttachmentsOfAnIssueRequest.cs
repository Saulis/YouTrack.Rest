using System;

namespace YouTrack.Rest.Requests
{
    class GetAttachmentsOfAnIssueRequest :  YouTrackRequest, IYouTrackGetRequest
    {
        public GetAttachmentsOfAnIssueRequest(string issueId) : base(String.Format("/rest/issue/{0}/attachment", issueId))
        {
        }
    }
}
