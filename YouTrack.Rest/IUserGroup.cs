using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IUserGroup
    {
        string Name { get; }
        void AssignRoleToAllProjects(string role);
        IEnumerable<IUserRole> Roles { get; }
    }
}
