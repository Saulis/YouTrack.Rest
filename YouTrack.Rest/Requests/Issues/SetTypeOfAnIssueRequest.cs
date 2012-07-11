using System;

namespace YouTrack.Rest.Requests.Issues
{
    class SetTypeOfAnIssueRequest : ApplyCommandToAnIssueRequest
    {
        public SetTypeOfAnIssueRequest(string issueId, string type) : base(issueId, String.Format("Type {0}", type))
        {
        }
    }
}