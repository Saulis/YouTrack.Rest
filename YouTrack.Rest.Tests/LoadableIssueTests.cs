using NUnit.Framework;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Interception;

namespace YouTrack.Rest.Tests
{
    class LoadableIssueTests : TestFor<LoadableIssue>
    {
        private IConnection connection;

        protected override LoadableIssue CreateSut()
        {
            connection = Mock<IConnection>();
            return new LoadableIssue("FOO-BAR", connection, Mock<IIssueRequestFactory>());
        }

        [Test]
        public void LoadSetLoaded()
        {
            ILoadable loadable = Sut;

            loadable.Load();

            Assert.IsTrue(loadable.IsLoaded);
        }

        [Test]
        public void IsNotLoadedWhenConstructed()
        {
            Assert.IsFalse(((ILoadable)Sut).IsLoaded);
        }

        [Test]
        public void IssueStatusNotLoadedAfterApplyingCommand()
        {
            Sut.Load();

            Sut.ApplyCommands("Foo", "Bar");

            Assert.IsFalse(Sut.IsLoaded);
        }
    }
}