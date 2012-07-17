using System;
using YouTrack.Rest.Deserialization;

namespace YouTrack.Rest.Requests.Users
{
    class AssignRoleToUserGroupRequest : YouTrackRequest, IYouTrackPutRequest
    {
        public AssignRoleToUserGroupRequest(string userGroup, string roleName)
            : base(String.Format("/rest/admin/group/{0}/role/{1}", userGroup, roleName))
        {
            Body = CreateUserRole(roleName);
        }

        private UserRole CreateUserRole(string roleName)
        {
            UserRole userRole = new UserRole();

            userRole.Name = roleName;

            return userRole;
        }
    }
}
