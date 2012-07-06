using System;

namespace YouTrack.Rest.Requests
{
    abstract class GetIssueRequest : YouTrackRequest, IYouTrackGetRequest<IIssue>
    {
        protected IIssue Issue { get; set; }
        protected IConnection Connection { get; set; }

        protected GetIssueRequest(IIssue issue, IConnection connection)
            : base(String.Format("/rest/issue/{0}", issue.Id))
        {
            Issue = issue;
            Connection = connection;
        }

        public abstract IIssue Execute();
    }
}