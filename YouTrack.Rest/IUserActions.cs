using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IUserActions
    {
        void JoinGroup(string groupName);
        IEnumerable<IUserGroup> Groups { get; }
        IEnumerable<IUserRole> Roles { get; }
    }
}