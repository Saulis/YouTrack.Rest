using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrack.Rest.Requests.Issues
{
    class GetIssueSyncRequest : GetIssueRequest
    {
        public GetIssueSyncRequest(IIssue issue, IConnection connection) : base(issue, connection)
        {
        }

        public override IIssue Execute()
        {
            Deserialization.Issue deserializedIssue = Connection.Get<Deserialization.Issue>(this);

            deserializedIssue.MapTo(Issue, Connection);
            OnExecuted();

            return Issue;
        }
    }
}
