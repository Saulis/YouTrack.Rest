namespace YouTrack.Rest
{
    public interface IProject : IProjectActions
    {
        string Description { get; }
        string Name { get; }
        int StartingNumber { get; }
        string ProjectLeadLogin { get; }
    }
}
