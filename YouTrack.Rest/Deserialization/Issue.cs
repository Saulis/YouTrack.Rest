using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Deserialization
{
    //Has to have name Issue for RestSharp deserialization to work properly.
    class Issue
    {
        public string Id { get; set; }
        public List<Field> Fields { get; set; }
        public List<Comment> Comments { get; set; } 

        public virtual IIssue GetIssue(IConnection connection)
        {
            Rest.Issue issue = new Rest.Issue(Id, connection);

            MapTo(issue, connection);

            return issue;
        }

        private int GetInt32(string name)
        {
            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetInt32();
            }

            throw new IssueDeserializationException(String.Format("Issue '{0}' has zero or multiple integer values for field '{1}'.", Id, name));
        }

        private DateTime GetDateTime(string name)
        {
            if(HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetDateTime();
            }

            throw new IssueDeserializationException(String.Format("Issue '{0}' has zero or multiple datetime values for field '{1}'.", Id, name));
        }

        private string GetString(string name, string defaultValue = null)
        {
            if(!HasFieldFor(name) && defaultValue != null)
            {
                return defaultValue;
            }

            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetValue();
            }

            throw new IssueDeserializationException(String.Format("Issue '{0}' has zero or multiple string values for field '{1}'.", Id, name));
        }

        private bool HasFieldFor(string name)
        {
            return Fields.Any(GetCompareNamesPredicate(name));
        }

        private bool HasSingleFieldFor(string name)
        {
            return Fields.Count(GetCompareNamesPredicate(name)) == 1;
        }

        private Field GetSingleFieldFor(string name)
        {
            return Fields.Single(GetCompareNamesPredicate(name));
        }

        private Func<Field, bool> GetCompareNamesPredicate(string name)
        {
            return f => f.Name.ToUpper() == name.ToUpper();
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