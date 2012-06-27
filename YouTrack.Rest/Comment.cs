namespace YouTrack.Rest
{
    class Comment : IComment
    {
        public Comment(string commentId)
        {
            Id = commentId;
        }

        public string Id { get; internal set; }
        public string Text { get; internal set; }
        public string IssueId { get; internal set; }
    }
}