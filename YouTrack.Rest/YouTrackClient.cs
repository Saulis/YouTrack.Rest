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

            connection = new Connection(restClient, session, new RestFileRequestFactory());
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
            return new IssueRepository(connection, new IssueFactory());
        }

        public IProjectRepository GetProjectRepository()
        {
            return new ProjectRepository(connection, new ProjectFactory());
        }

        public IUserRepository GetUserRepository()
        {
            return new UserRepository(connection);
        }
    }
}
