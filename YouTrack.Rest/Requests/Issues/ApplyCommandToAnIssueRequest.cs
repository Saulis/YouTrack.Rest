using System;

namespace YouTrack.Rest.Requests.Issues
{
    class ApplyCommandToAnIssueRequest : YouTrackRequest, IYouTrackPostRequest
    {
        public ApplyCommandToAnIssueRequest(string issueId, string command = null, string comment = null)
            : base(String.Format("/rest/issue/{0}/execute", issueId))
        {
            ResourceBuilder.AddParameter("command", command);
            ResourceBuilder.AddParameter("comment", comment);
        }

    }
}
