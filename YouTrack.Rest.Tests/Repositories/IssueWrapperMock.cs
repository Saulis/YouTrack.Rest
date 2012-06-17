namespace YouTrack.Rest.Tests.Repositories
{
    class IssueWrapperMock : IssueWrapper
    {
        private readonly IIssue issue;

        public IssueWrapperMock(IIssue issue)
        {
            this.issue = issue;
        }

        public override IIssue Deserialize()
        {
            return issue;
        }
    }
}