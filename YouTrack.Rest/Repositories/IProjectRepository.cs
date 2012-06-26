namespace YouTrack.Rest.Repositories
{
    public interface IProjectRepository
    {
        IProjectProxy GetProjectProxy(string projectid);
    }
}