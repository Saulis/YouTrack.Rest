using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IUserGroup
    {
        string Name { get; }
        void AssignRole(string role);
        IEnumerable<IUserRole> Roles { get; }
    }
}
