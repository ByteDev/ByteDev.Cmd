using System;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests
{
    [TestFixture]
    public class TableTests
    {
        [TestFixture]
        public class Constructor : TableTests
        {
            [Test]
            public void WhenColumnsLessThanOne_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Table(0, 1));
            }

            [Test]
            public void WhenRowsLessThanOne_ThenThrowException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() => new Table(1, 0));
            }

            [Test]
            public void WhenRowsAndColumnsOverZero_ThenSetProperties()
            {
                var sut = new Table(1, 2);

                Assert.That(sut.Columns, Is.EqualTo(1));
                Assert.That(sut.Rows, Is.EqualTo(2));
            }
            
            [Test]
            public void WhenDefaultValueSet_ThenSetAllElements()
            {
                var sut = new Table(2, 1, "A");

                Assert.That(sut.GetValue(new TablePosition(0, 0)), Is.EqualTo("A"));
                Assert.That(sut.GetValue(new TablePosition(1, 0)), Is.EqualTo("A"));
            }
        }

        [TestFixture]
        public class GetValue : TableTests
        {
            [Test]
            public void WhenPositionOutOfBoundsOnX_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetValue(new TablePosition(2, 0)));
            }
            
            [Test]
            public void WhenPositionOutOfBoundsOnY_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetValue(new TablePosition(0, 2)));
            }

            [Test]
            public void WhenCellIsNull_ThenReturnNull()
            {
                var sut = new Table(2, 2);

                var result = sut.GetValue(new TablePosition(0, 0));

                Assert.That(result, Is.Null);
            }
        }

        [TestFixture]
        public class InsertValue : TableTests
        {
            [Test]
            public void WhenPositionOutOfBoundsOnX_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.InsertValue(new TablePosition(2, 0), "A"));
            }


            [Test]
            public void WhenPositionOutOfBoundsOnY_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.InsertValue(new TablePosition(0, 2), "A"));
            }

            [Test]
            public void WhenPositionInBounds_ThenUpdateSingleCellValue()
            {
                var sut = new Table(2, 2, "A");
                var position = new TablePosition(0, 0);

                sut.InsertValue(position, "X");

                Assert.That(sut.GetValue(position), Is.EqualTo("X"));
                Assert.That(sut.GetValue(new TablePosition(0, 1)), Is.EqualTo("A"));
                Assert.That(sut.GetValue(new TablePosition(1, 0)), Is.EqualTo("A"));
                Assert.That(sut.GetValue(new TablePosition(1, 1)), Is.EqualTo("A"));
            }
        }
    }
}