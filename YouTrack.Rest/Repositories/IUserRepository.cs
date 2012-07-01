namespace YouTrack.Rest.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(string login, string password, string email, string fullname = null);
        void DeleteUser(string login);
        bool UserExists(string login);
    }
}