using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace YouTrack.Rest.Tests
{
    class IssueDeserializerTests : TestFor<IssueWrapper>
    {
        private IConnection connection;
        private const string IssueId = "FOO-BAR";
        private const string ProjectShortName = "FOO";
        private const string Summary = "Summary";
        private const string Type = "Bug";

        protected override void SetupDependencies()
        {
            Sut.Id = IssueId;
            Sut.Fields = CreateFields();
            connection = Mock<IConnection>();
        }

        private List<Field> CreateFields()
        {
            List<Field> fields = new List<Field>();

            fields.Add(CreateField("projectShortName", ProjectShortName));
            fields.Add(CreateField("summary", Summary));
            fields.Add(CreateField("Type", Type));

            return fields;
        }

        private static Field CreateField(string name, string value)
        {
            Value_ value_ = new Value_() {Value = value};

            Field field = new Field() {Name = name, Values = new List<Value_> { value_ }};

            return field;
        }

        [Test]
        public void IdIsDeserialized()
        {
            Assert.That(Sut.Deserialize(connection).Id, Is.EqualTo(IssueId));
        }

        [Test]
        public void ProjectShortNameIsDeserialized()
        {
            Assert.That(Sut.Deserialize(connection).ProjectShortName, Is.EqualTo(ProjectShortName));
        }

        [Test]
        public void SummaryIsDeserialized()
        {
            Assert.That(Sut.Deserialize(connection).Summary, Is.EqualTo(Summary));
        }

        [Test]
        public void TypeIsDeserialized()
        {
            Assert.That(Sut.Deserialize(connection).Type, Is.EqualTo(Type));
        }
    }
}
