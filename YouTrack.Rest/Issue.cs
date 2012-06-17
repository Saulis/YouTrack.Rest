namespace YouTrack.Rest
{
    class Issue : IIssue
    {
        public string Id { get; set; }

        public string Summary { get; set; }

        public string Type { get; set; }

        public string ProjectShortName { get; set; }
    }
}