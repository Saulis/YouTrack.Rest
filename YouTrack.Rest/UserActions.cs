using System.Collections.Generic;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest
{
    class UserActions : IUserActions
    {
        private readonly IConnection connection;
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
        }

        public IEnumerable<IUserGroup> Groups
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}