using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests
{
    class ConnectionTests : TestFor<Connection>
    {

        [Test]
        public void Delete()
        {
            Sut.Delete(Mock<IYouTrackDeleteRequest>());
        }

        [Test]
        public void Get()
        {
            Sut.Get<TestItem>(Mock<IYouTrackGetRequest>());
        }

        [Test]
        public void Put()
        {
            Sut.Put(Mock<IYouTrackPutRequest>());
        }

        class TestItem
        {
             
        }
    }
}
