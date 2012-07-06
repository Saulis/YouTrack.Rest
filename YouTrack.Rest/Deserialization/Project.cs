using System;

namespace YouTrack.Rest.Deserialization
{
    class Project
    {
        public string Name { get; set; }
        public string Lead { get; set; }
        public string Description { get; set; }

        public virtual void MapTo(Rest.Project project)
        {
            project.Description = Description;
            project.Name = Name;
            project.ProjectLeadLogin = Lead;
        }
    }
}