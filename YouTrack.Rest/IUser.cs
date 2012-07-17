namespace YouTrack.Rest
{
    public interface IUser : IUserActions
    {
        string Login { get; }
        string FullName { get; }
        string Email { get; }
    }
}