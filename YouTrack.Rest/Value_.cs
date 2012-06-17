namespace YouTrack.Rest
{
    internal class Value_
    {
        public string Value { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}