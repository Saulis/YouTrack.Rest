using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class RestRequestResourceBuilderTests : TestFor<RestRequestResourceBuilder>
    {
        protected override RestRequestResourceBuilder CreateSut()
        {
            return new RestRequestResourceBuilder("foobase");
        }

        [Test]
        public void StringParameterAdded()
        {
            Sut.AddParameter("foo", "bar");

            Assert.That(Sut.ToString(), Is.EqualTo("foobase?foo=bar"));
        }

        [Test]
        public void ExceptionThrownIfSameParameterAddedTwice()
        {
            Sut.AddParameter("foo", "bar");

            Assert.Throws<ParameterAlreadyAddedException>(() => Sut.AddParameter("foo", "foo"));
        }
    }
}
