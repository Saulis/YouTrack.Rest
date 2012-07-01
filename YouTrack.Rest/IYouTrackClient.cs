using YouTrack.Rest.Repositories;

namespace YouTrack.Rest
{
    public interface IYouTrackClient
    {
        IConnection GetConnection();
        ISession GetSession();
        IIssueRepository GetIssueRepository();
        IProjectRepository GetProjectRepository();
        IUserRepository GetUserRepository();
    }
}