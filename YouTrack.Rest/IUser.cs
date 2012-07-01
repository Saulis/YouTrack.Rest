namespace YouTrack.Rest
{
    public interface IUser
    {
        string Login { get; }
        string FullName { get; }
        string Email { get; }
    }
}