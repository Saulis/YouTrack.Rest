using System.Collections.Generic;

namespace YouTrack.Rest.Deserialization
{
    class Change : HasFieldsBase
    {
        public Change() : base("Change")
        {
        }

        public IChange GetChange(IConnection connection)
        {
            Rest.Change change = new Rest.Change();

            MapTo(change);

            return change;
        }

        public void MapTo(Rest.Change change)
        {
            change.UpdaterName = GetString("updaterName", "");
            change.Updated = GetDateTime("updated");

            MapFields(change.ChangedFields);
        }

        private void MapFields(IDictionary<string, IChangedField> fields)
        {
            fields.Clear();

            foreach (Field field in Fields)
            {
                if (!string.IsNullOrEmpty(field.Name))
                {
                    fields[field.Name] = new ChangedField(field);
                }
            }
        }
    }
}