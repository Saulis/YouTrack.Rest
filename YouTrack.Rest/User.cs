namespace YouTrack.Rest
{
    class User : UserActions, IUser
    {
        public User(string login, IConnection connection) : base(login, connection)
        {
        }

        public string FullName { get; internal set; }
        public string Email { get; internal set; }
    }
}
