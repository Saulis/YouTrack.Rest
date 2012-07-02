using System;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Features.Administration.Projects
{
    public class ProjectSteps : Steps.Steps
    {
        protected IProjectRepository ProjectRepository
        {
            get { return StepHelper.GetProjectRepository(); }
        }

        protected void CreateProject(string projectid, string projectname, int startingNumber, string projectleadlogin, string description)
        {
            Console.WriteLine("Creating project {0}", projectid);

            ProjectRepository.CreateProject(projectid, projectname, projectleadlogin, startingNumber, description);
        }

        protected bool ProjectExists(string projectId)
        {
            Console.WriteLine("Checking if project {0} exists", projectId);

            return ProjectRepository.ProjectExists(projectId);
        }
    }
}