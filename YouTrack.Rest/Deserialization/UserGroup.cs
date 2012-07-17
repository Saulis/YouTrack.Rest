namespace YouTrack.Rest.Deserialization
{
    class UserGroup
    {
        public string Name { get; set; }

        public virtual IUserGroup GetUserGroup(IConnection connection)
        {
            return new Rest.UserGroup(Name, connection);
        }
    }
}
