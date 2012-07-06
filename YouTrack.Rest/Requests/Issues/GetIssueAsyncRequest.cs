using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrack.Rest.Requests.Issues
{
    class GetIssueAsyncRequest : GetIssueRequest
    {
        public GetIssueAsyncRequest(IIssue issue, IConnection connection) : base(issue, connection)
        {
        }

        public override IIssue Execute()
        {
            Connection.GetAsync<Deserialization.Issue>(this, x =>
                                                                 {
                                                                     x.MapTo(Issue, Connection);
                                                                     OnExecuted();
                                                                 });

            return Issue;
        }
    }
}
