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
    }
}