using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Deserialization
{
    abstract class HasFieldsBase
    {
        private readonly string type;

        public string Id { get; set; }

        public List<Field> Fields { get; set; }

        protected HasFieldsBase(string type)
        {
            this.type = type;
        }

        protected bool HasFieldFor(string name)
        {
            return Fields.Any(GetCompareNamesPredicate(name));
        }

        protected bool HasSingleFieldFor(string name)
        {
            return Fields.Count(GetCompareNamesPredicate(name)) == 1;
        }

        protected Field GetSingleFieldFor(string name)
        {
            return Fields.Single(GetCompareNamesPredicate(name));
        }

        private Func<Field, bool> GetCompareNamesPredicate(string name)
        {
            return f => f.Name.ToUpper() == name.ToUpper();
        }

        protected int GetInt32(string name)
        {
            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetInt32();
            }

            throw new IssueDeserializationException(String.Format("{0} '{1}' has zero or multiple integer values for field '{2}'.", type, Id, name));
        }

        protected DateTime GetDateTime(string name)
        {
            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetDateTime();
            }

            throw new IssueDeserializationException(String.Format("{0} '{1}' has zero or multiple datetime values for field '{2}'.", type, Id, name));
        }

        protected string GetString(string name, string defaultValue = null)
        {
            if (!HasFieldFor(name) && defaultValue != null)
            {
                return defaultValue;
            }

            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetValue();
            }

            throw new IssueDeserializationException(String.Format("{0} '{1}' has zero or multiple string values for field '{2}'.", type, Id, name));
        }
    }
}