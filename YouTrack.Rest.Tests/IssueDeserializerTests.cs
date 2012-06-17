using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace YouTrack.Rest.Tests
{
    class IssueDeserializerTests : TestFor<IssueDeserializer>
    {
        private const string IssueId = "FOO-BAR";
        private const string ProjectShortName = "FOO";
        private const string Summary = "Summary";
        private const string Type = "Bug";

        [Test]
        public void IdIsDeserialized()
        {
            Assert.That(Sut.Deserialize().Id, Is.EqualTo(IssueId));
        }

        [Test]
        public void ProjectShortNameIsDeserialized()
        {
            Assert.That(Sut.Deserialize().ProjectShortName, Is.EqualTo(ProjectShortName));
        }

        [Test]
        public void SummaryIsDeserialized()
        {
            Assert.That(Sut.Deserialize().Summary, Is.EqualTo(Summary));
        }

        [Test]
        public void TypeIsDeserialized()
        {
            Assert.That(Sut.Deserialize().Type, Is.EqualTo(Type));
        }
    }
}
