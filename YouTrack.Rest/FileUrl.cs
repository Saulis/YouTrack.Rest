namespace YouTrack.Rest
{
    class FileUrl : IAttachment
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string AuthorLogin { get; set; }
        public string Group { get; set; }
        public string Created { get; set; }
    }
}