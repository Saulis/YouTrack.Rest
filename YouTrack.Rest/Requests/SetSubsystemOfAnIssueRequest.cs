using System;

namespace YouTrack.Rest.Requests
{
    class SetSubsystemOfAnIssueRequest : ApplyCommandToAnIssueRequest
    {
        public SetSubsystemOfAnIssueRequest(string issueId, string subsystem) : base(issueId, command: String.Format("Subsystem {0}", subsystem))
        {
        }
    }
}