using System.Collections.Generic;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest
{
    class UserGroup : IUserGroup
    {
        private readonly IConnection connection;
        private IEnumerable<IUserRole> roles;
        public string Name { get; private set; }

        public UserGroup(string name, IConnection connection)
        {
            Name = name;
            this.connection = connection;
        }

        public void AssignRoleToAllProjects(string role)
        {
            AssignRoleToUserGroupRequest request = new AssignRoleToUserGroupRequest(Name, role);

            connection.Put(request);
        }

        public IEnumerable<IUserRole> Roles
        {
            get { return roles ?? (roles = GetRoles()); }
        }

        private IEnumerable<IUserRole> GetRoles()
        {
            GetUserGroupRolesRequest request = new GetUserGroupRolesRequest(Name);

            UserRoleCollection userRoleCollection = connection.Get<UserRoleCollection>(request);

            return userRoleCollection.UserRoles;
        }
    }
}
