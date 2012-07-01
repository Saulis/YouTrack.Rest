namespace YouTrack.Rest.Repositories
{
    public interface IUserRepository
    {
        void CreateUser(string login, string password, string email, string fullname = null);
    }
}