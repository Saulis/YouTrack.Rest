using YouTrack.Rest.Deserialization;

namespace YouTrack.Rest.Tests.Repositories
{
    class IssueMock : Deserialization.Issue
    {
        private readonly IIssue issue;

        public IssueMock(IIssue issue)
        {
            this.issue = issue;
        }

        public override IIssue GetIssue(IConnection connection)
        {
            return issue;
        }
    }
}