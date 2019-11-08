using System;
using ByteDev.Cmd.Tables;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Tables
{
    [TestFixture]
    public class TablePositionTests
    {
        [TestFixture]
        public class Constructor : TablePositionTests
        {
            [Test]
            public void WhenColumnNumberLessThanZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new CellPosition(-1, 0));
            }

            [Test]
            public void WhenRowNumberLessThanZero_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new CellPosition(0, -1));
            }

            [Test]
            public void WhenColumnAndRowValid_ThenSetProperties()
            {
                var sut = new CellPosition(0, 1);

                Assert.That(sut.Column, Is.EqualTo(0));
                Assert.That(sut.Row, Is.EqualTo(1));
            }
        }

        [TestFixture]
        public class ToStringOverride : TablePositionTests
        {
            [Test]
            public void WhenCalled_ThenReturnsStringRepresentation()
            {
                var sut = new CellPosition(0, 1);

                var result = sut.ToString();

                Assert.That(result, Is.EqualTo("0x1"));
            }
        }
    }
}