namespace YouTrack.Rest.Repositories
{
    public interface IProjectRepository
    {
        IProject GetProject(string projectId);
        IProject CreateProject(string projectId, string projectName, string projectLeadLogin, int startingNumber = 1, string description = null);
        bool ProjectExists(string projectId);
        void DeleteProject(string projectid);
    }
}