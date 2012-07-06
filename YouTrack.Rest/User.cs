namespace YouTrack.Rest
{
    class User : UserActions, IUser
    {
        public User(string login)
        {
            Login = login;
        }

        public string Login { get; private set; }
        public string FullName { get; internal set; }
        public string Email { get; internal set; }
    }
}
