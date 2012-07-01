namespace YouTrack.Rest.Deserialization
{
    class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public IUser GetUser()
        {
            Rest.User user = new Rest.User(Login);

            MapTo(user);

            return user;
        }

        private void MapTo(Rest.User user)
        {
            user.Email = Email;
            user.FullName = FullName;
        }
    }
}
