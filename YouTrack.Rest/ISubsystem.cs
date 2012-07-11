namespace YouTrack.Rest
{
    public interface ISubsystem
    {
        bool IsDefault { get; }
        string Name { get; }
    }

}
