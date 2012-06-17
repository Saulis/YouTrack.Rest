namespace YouTrack.Rest.Tests.Repositories
{
    class IssueDeserializerMock : IssueDeserializer
    {
        private readonly IIssue issue;

        public IssueDeserializerMock(IIssue issue)
        {
            this.issue = issue;
        }

        public override IIssue Deserialize()
        {
            return issue;
        }
    }
}