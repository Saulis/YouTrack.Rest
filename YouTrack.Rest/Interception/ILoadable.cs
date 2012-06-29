namespace YouTrack.Rest.Interception
{
    public interface ILoadable
    {
        bool IsLoaded { get; }
        void Load();
    }
}