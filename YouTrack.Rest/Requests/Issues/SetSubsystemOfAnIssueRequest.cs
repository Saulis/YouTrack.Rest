using System;

namespace YouTrack.Rest.Requests.Issues
{
    class SetSubsystemOfAnIssueRequest : ApplyCommandToAnIssueRequest
    {
        public SetSubsystemOfAnIssueRequest(string issueId, string subsystem) : base(issueId, command: String.Format("Subsystem {0}", subsystem))
        {
        }
    }
}