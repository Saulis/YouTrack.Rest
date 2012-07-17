namespace YouTrack.Rest.Deserialization
{
    class Subsystem : ISubsystem
    {
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
