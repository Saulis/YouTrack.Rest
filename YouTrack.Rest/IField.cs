namespace YouTrack.Rest
{
    public interface IField
    {
        string Name { get; }
    }

    class Field : IField
    {
        public string Name { get; set; }
    }
}