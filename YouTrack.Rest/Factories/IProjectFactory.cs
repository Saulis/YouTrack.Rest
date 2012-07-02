namespace YouTrack.Rest.Factories
{
    public interface IProjectFactory
    {
        IProject CreateProject(string projectId, IConnection connection);
    }
}