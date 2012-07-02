namespace YouTrack.Rest
{
    public interface IProject
    {
        string Id { get; }
        string Description { get; }
        string Name { get; }
        int StartingNumber { get; }
        string ProjectLeadLogin { get; }
    }
}
