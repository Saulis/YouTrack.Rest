namespace YouTrack.Rest.Repositories
{
    public interface IProjectRepository
    {
        IProjectProxy GetProjectProxy(string projectid);
        void CreateProject(string projectId, string projectName, string projectLeadLogin, int startingNumber = 1, string description = null);
        bool ProjectExists(string projectId);
    }
}