using System;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests
{
    [TestFixture]
    public class TablePositionTests
    {
        [TestFixture]
        public class Constructor : TablePositionTests
        {
            [Test]
            public void WhenXLessThanZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new TablePosition(-1, 0));
            }

            [Test]
            public void WhenYLessThanZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new TablePosition(0, -1));
            }

            [Test]
            public void WhenXAndYValid_ThenSetProperties()
            {
                var sut = new TablePosition(0, 1);

                Assert.That(sut.X, Is.EqualTo(0));
                Assert.That(sut.Y, Is.EqualTo(1));
            }
        }

        [TestFixture]
        public class ToStringOverride : TablePositionTests
        {
            [Test]
            public void WhenCalled_ThenReturnsStringRepresentation()
            {
                var sut = new TablePosition(0, 1);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("0x1"));
            }
        }
    }
}