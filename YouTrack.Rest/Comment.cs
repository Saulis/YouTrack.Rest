namespace YouTrack.Rest
{
    class Comment : IComment
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public string IssueId { get; set; }
        public string Deleted { get; set; }
        public string Text { get; set; }
        public string ShownForIssueAuthor { get; set; }
        public string Created { get; set; }
    }
}