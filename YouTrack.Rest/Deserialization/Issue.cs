using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest.Deserialization
{
    //Has to have name Issue for RestSharp deserialization to work properly.
    class Issue : HasFieldsBase
    {
        public List<Comment> Comments { get; set; }

        public Issue() : base("Issue")
        {
        }

        public virtual IIssue GetIssue(IConnection connection)
        {
            Rest.Issue issue = new Rest.Issue(Id, connection);

            MapTo(issue, connection);

            return issue;
        }

        public void MapTo(Rest.Issue issue, IConnection connection)
        {
            issue.CommentsCount = GetInt32("commentsCount");
            issue.Created = GetDateTime("created");
            issue.Description = GetString("description", "");
            issue.NumberInProject = GetInt32("numberInProject");
            issue.Priority = GetString("priority");
            issue.ProjectShortName = GetString("projectShortName");
            issue.ReporterName = GetString("reporterName");
            issue.State = GetString("state");
            issue.Subsystem = GetString("subsystem");
            issue.Summary = GetString("summary");
            issue.Type = GetString("Type");
            issue.Updated = GetDateTime("updated");
            issue.UpdaterName = GetString("updaterName");
            issue.VotesCount = GetInt32("votes");

            MapFields(issue.Fields);
            issue.Comments = Comments.Select(c => c.GetComment(connection));
        }

        private void MapFields(IDictionary<string, IEnumerable<string>> fields)
        {
            fields.Clear();
            
            foreach (Field field in Fields)
            {
                if (!string.IsNullOrEmpty(field.Name))
                {
                    fields[field.Name] = field.Values.ConvertAll(v => v.ToString());
                }
            }
        }
    }
}