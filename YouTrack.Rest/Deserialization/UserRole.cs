using RestSharp.Serializers;

namespace YouTrack.Rest.Deserialization
{
    [SerializeAs(Name = "userRole")]
    class UserRole : IUserRole
    {
        [SerializeAs(Attribute = true, Name = "name")]
        public string Name { get; set; }
    }
}
