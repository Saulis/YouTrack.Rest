using RestSharp;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest
{
    public class YouTrackClient : IYouTrackClient
    {
        private readonly IConnection connection;
        private readonly ISession session;

        public YouTrackClient(string baseUrl, string login, string password)
        {
            RestClient restClient = new RestClient(baseUrl);
            session = new Session(restClient, login, password);

            connection = new Connection(restClient, session);
        }

        public IConnection GetConnection()
        {
            return connection;
        }

        public ISession GetSession()
        {
            return session;
        }

        public IIssueRepository GetIssueRepository()
        {
            return new IssueRepository(connection, new IssueFactory(), GetIssueRequestFactory());
        }

        protected virtual IIssueRequestFactory GetIssueRequestFactory()
        {
            return new IssueSyncRequestFactory();
        }

        public IProjectRepository GetProjectRepository()
        {
            return new ProjectRepository(connection, new ProjectFactory(), GetIssueRequestFactory());
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository(connection);
        }
    }

    public class AsyncYouTrackClient: YouTrackClient
    {
        public AsyncYouTrackClient(string baseUrl, string login, string password) : base(baseUrl, login, password)
        {
        }

        protected override IIssueRequestFactory GetIssueRequestFactory()
        {
            return new IssueAsyncRequestFactory();
        }
    }
}
