using System.Collections.Generic;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly IConnection connection;

        public UserRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public void CreateUser(string login, string password, string email, string fullname = null)
        {
            connection.Put(new CreateANewUserRequest(login, password, email, fullname));
        }

        public void DeleteUser(string login)
        {
            connection.Delete(new DeleteUserRequest(login));
        }

        public bool UserExists(string login)
        {
            //Relies on the "not found" exception if user doesn't exist. Could use some improving.

            try
            {
                connection.Get(new GetUserRequest(login));

                return true;
            }
            catch(RequestNotFoundException)
            {
                return false;
            }
        }

        public IUser GetUser(string login)
        {
            Deserialization.User user = connection.Get<Deserialization.User>(new GetUserRequest(login));

            return user.GetUser(connection);
        }

        public IUserGroup CreateUserGroup(string userGroupName)
        {
            CreateUserGroupRequest request = new CreateUserGroupRequest(userGroupName);

            connection.Put(request);

            return new UserGroup(userGroupName, connection);
        }

        public IEnumerable<IUserGroup> GetUserGroups()
        {
            GetAllUserGroupsRequest request = new GetAllUserGroupsRequest();

            UserGroupCollection userGroupCollection = connection.Get<UserGroupCollection>(request);

            return userGroupCollection.GetUserGroups(connection);
        }

        public void DeleteUserGroup(string userGroupName)
        {
            DeleteUserGroupRequest request = new DeleteUserGroupRequest(userGroupName);

            connection.Delete(request);
        }
    }
}