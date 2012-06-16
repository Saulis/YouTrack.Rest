using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IIssue
    {
        string Id { get; set; }
    }

    class Issue : IIssue
    {
        public string Id { get; set; }
        public List<Field> Field { get; set; }
    }
}
