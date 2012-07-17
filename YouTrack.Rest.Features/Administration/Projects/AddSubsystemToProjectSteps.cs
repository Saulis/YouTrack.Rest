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
    [Scope(Feature = "Add subsystem to project")]
    public class AddSubsystemToProjectSteps : ProjectSteps
    {
        [Given(@"I have created a project")]
        public void GivenIHaveCreatedAProject()
        {
            CreateProject("FOO", "Foobar", 1, TestSettings.Username, "Desc");
        }

        [When(@"I add subsystem to the project")]
        public void WhenIAddSubsystemToTheProject()
        {
            IProject project = GetSavedProject();

            project.AddSubsystem("Test");
        }

        [Then(@"the project has a subsystem")]
        public void ThenTheProjectHasASubsystem()
        {
            IEnumerable<ISubsystem> subsystems = GetSavedProject().Subsystems;

            Assert.That(subsystems.Count(), Is.EqualTo(2));
            Assert.That(subsystems.Select(s => s.Name), Contains.Item("Test"));
        }
    }
}
