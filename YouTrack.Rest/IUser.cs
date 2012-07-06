using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IUserActions
    {
        void JoinGroup(string groupName);
        IEnumerable<IUserGroup> Groups { get; }
    }

    public interface IUser : IUserActions
    {
        string Login { get; }
        string FullName { get; }
        string Email { get; }
    }
}