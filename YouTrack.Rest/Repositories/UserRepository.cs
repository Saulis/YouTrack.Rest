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
    }
}