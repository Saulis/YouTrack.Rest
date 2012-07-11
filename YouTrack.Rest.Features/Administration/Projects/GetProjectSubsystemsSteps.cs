using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;
using YouTrack.Rest.Features.Steps;

namespace YouTrack.Rest.Features.Administration.Projects
{
    [Binding]
    [Scope(Feature = "Get projects subsystems")]
    public class GetProjectSubsystemsSteps : ProjectSteps
    {
        [Given("I have created a project")]
        public void GivenIHaveCreatedAProject()
        {
            CreateProject("FOO", "Foobar", 1, TestSettings.Username, "desc");
        }

        [When("I fetch the project")]
        public void WhenIFetchTheProject()
        {
            //Make the project load
            string description = GetSavedProject().Description;
        }

        [Then(@"the project has default subsystem ""No subsystem""")]
        public void ThenTheProjectHasDefaultSubsystem()
        {
            IProject project = GetSavedProject();

            IEnumerable<ISubsystem> subsystems = project.Subsystems;

            Assert.That(subsystems.Count(), Is.EqualTo(1));

            ISubsystem subsystem = subsystems.Single();

            Assert.That(subsystem.IsDefault);
            Assert.That(subsystem.Name, Is.EqualTo("No subsystem"));
        }
    }
}
