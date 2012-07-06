using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Factories;

namespace YouTrack.Rest.Deserialization
{
    //Has to have name Issue for RestSharp deserialization to work properly.
    class Issue
    {
        public string Id { get; set; }
        public List<Field> Fields { get; set; }
        public List<Comment> Comments { get; set; }

        public virtual IIssue GetIssue(IConnection connection, IIssueRequestFactory issueRequestFactory)
        {
            Rest.Issue issue = new Rest.Issue(Id, connection, issueRequestFactory);

            MapTo(issue, connection);

            return issue;
        }

        private int GetInt32(string name)
        {
            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetInt32();
            }

            throw new IssueSerializationException(String.Format("Issue [{0}] has zero or multiple integer values for field [{1}].", Id, name));
        }

        private DateTime GetDateTime(string name)
        {
            if(HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetDateTime();
            }

            throw new IssueSerializationException(String.Format("Issue [{0}] has zero or multiple datetime values for field [{1}].", Id, name));
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

            throw new IssueSerializationException(String.Format("Issue [{0}] has zero or multiple string values for field [{1}].", Id, name));
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

        public virtual void MapTo(Rest.Issue issue, IConnection connection)
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

            issue.Comments = Comments.Select(c => c.GetComment(connection));
        }

        public virtual void MapTo(IIssue issue, IConnection connection)
        {
            //TODO: A better solution than casting...
            if(issue is Rest.Issue)
            {
                MapTo(issue as Rest.Issue, connection);
            }
        }
    }
}