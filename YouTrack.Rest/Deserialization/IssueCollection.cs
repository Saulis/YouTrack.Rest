using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest.Deserialization
{
    class IssueCollection
    {
        public List<Issue> Issues { get; set; } 

        public ICollection<IIssue> GetIssues(IConnection connection)
        {
            return Issues.Select(i => i.GetIssue(connection)).ToList();
        }
    }
}