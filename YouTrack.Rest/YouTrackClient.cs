using RestSharp;
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
            return new IssueRepository(connection);
        }

        public IProjectRepository GetProjectRepository()
        {
            return new ProjectRepository(connection);
        }
    }
}
