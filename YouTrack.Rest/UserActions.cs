using System.Collections.Generic;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest
{
    class UserActions : IUserActions
    {
        private readonly IConnection connection;
        private IEnumerable<IUserGroup> groups;
        public string Login { get; private set; }

        public UserActions(string login, IConnection connection)
        {
            Login = login;
            this.connection = connection;
        }

        public void JoinGroup(string groupName)
        {
            AddUserToGroupRequest request = new AddUserToGroupRequest(Login, groupName);

            connection.Post(request);

            groups = null;
        }

        public IEnumerable<IUserGroup> Groups
        {
            get { return groups ?? (groups = GetGroups()); }
        }

        private IEnumerable<IUserGroup> GetGroups()
        {
            GetUsersGroupsRequest request = new GetUsersGroupsRequest(Login);

            UserGroupCollection userGroupCollection = connection.Get<UserGroupCollection>(request);

            return userGroupCollection.UserGroups;
        }
    }
}