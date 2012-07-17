using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest.Deserialization
{
    class UserGroupCollection
    {
        public List<UserGroup> UserGroups { get; set; }

        public virtual IEnumerable<IUserGroup> GetUserGroups(IConnection connection)
        {
            return UserGroups.Select(ug => ug.GetUserGroup(connection));
        }
    }
}
