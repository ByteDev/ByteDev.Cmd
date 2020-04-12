using System;
using System.Linq;
using ByteDev.Cmd.Tables;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Tables
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

                Assert.That(sut.GetCell(new CellPosition(0, 0)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("A"));
            }
        }

        [TestFixture]
        public class GetCell : TableTests
        {
            [Test]
            public void WhenPositionOutOfBoundsOnX_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetCell(new CellPosition(2, 0)));
            }
            
            [Test]
            public void WhenPositionOutOfBoundsOnY_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetCell(new CellPosition(0, 2)));
            }

            [Test]
            public void WhenCellIsNull_ThenReturnNull()
            {
                var sut = new Table(2, 2);

                var result = sut.GetCell(new CellPosition(0, 0));

                Assert.That(result, Is.Null);
            }
        }

        [TestFixture]
        public class UpdateCell : TableTests
        {
            [Test]
            public void WhenPositionOutOfBoundsOnX_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.UpdateCell(new CellPosition(2, 0), new Cell("A")));
            }


            [Test]
            public void WhenPositionOutOfBoundsOnY_ThenThrowException()
            {
                var sut = new Table(2, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.UpdateCell(new CellPosition(0, 2), new Cell("A")));
            }

            [Test]
            public void WhenPositionInBounds_ThenUpdateSingleCellValue()
            {
                var sut = new Table(2, 2, "A");
                var position = new CellPosition(0, 0);

                sut.UpdateCell(position, new Cell("X"));

                Assert.That(sut.GetCell(position).Value, Is.EqualTo("X"));
                Assert.That(sut.GetCell(new CellPosition(0, 1)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(1, 1)).Value, Is.EqualTo("A"));
            }
        }

        [TestFixture]
        public class UpdateRow : TableTests
        {
            private Table _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new Table(2, 2, "A");
            }
            

            [Test]
            public void WhenValuesIsNull_ThenThrowException()
            {
                var position = new CellPosition(0, 0);

                Assert.Throws<ArgumentNullException>(() => _sut.UpdateRow(position, null));
            }

            [Test]
            public void WhenRowPositionGreaterThanOrEqualToTableRowSize_ThenThrowException()
            {
                var position = new CellPosition(0, 2);

                Assert.Throws<ArgumentOutOfRangeException>(() => _sut.UpdateRow(position, new[] { new Cell("X"), new Cell("Y") }));
            }

            [Test]
            public void WhenColumnPositionGreaterThanOrEqualToTableColumnSize_ThenThrowException()
            {
                var position = new CellPosition(2, 0);

                Assert.Throws<ArgumentOutOfRangeException>(() => _sut.UpdateRow(position, new[] { new Cell("X"), new Cell("Y") }));
            }

            [Test]
            public void WhenValuesIsEmpty_ThenDoNothing()
            {
                var position = new CellPosition(0, 0);

                _sut.UpdateRow(position, new Cell[0]);

                Assert.That(_sut.GetCell(new CellPosition(0, 0)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(0, 1)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(1, 1)).Value, Is.EqualTo("A"));
            }

            [Test]
            public void WhenValuesSameLengthAsNumberColumns_ThenUpdateCells()
            {
                var position = new CellPosition(0, 0);

                _sut.UpdateRow(position, new []{ new Cell("X"), new Cell("Y") });

                Assert.That(_sut.GetCell(new CellPosition(0, 0)).Value, Is.EqualTo("X"));
                Assert.That(_sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("Y"));
                Assert.That(_sut.GetCell(new CellPosition(0, 1)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(1, 1)).Value, Is.EqualTo("A"));
            }

            [Test]
            public void WhenValuesShorterThanNumberOfColumns_ThenUpdateCells()
            {
                var position = new CellPosition(0, 0);

                _sut.UpdateRow(position, new[] { new Cell("X") });

                Assert.That(_sut.GetCell(new CellPosition(0, 0)).Value, Is.EqualTo("X"));
                Assert.That(_sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(0, 1)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(1, 1)).Value, Is.EqualTo("A"));
            }

            [Test]
            public void WhenValuesLongerThanNumberOfColumns_ThenUpdateCells()
            {
                var position = new CellPosition(0, 0);

                _sut.UpdateRow(position, new[] { new Cell("X"), new Cell("Y"), new Cell("Z") });

                Assert.That(_sut.GetCell(new CellPosition(0, 0)).Value, Is.EqualTo("X"));
                Assert.That(_sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("Y"));
                Assert.That(_sut.GetCell(new CellPosition(0, 1)).Value, Is.EqualTo("A"));
                Assert.That(_sut.GetCell(new CellPosition(1, 1)).Value, Is.EqualTo("A"));
            }

            [Test]
            public void WhenStartingColumnIsNotZero_ThenUpdateCells()
            {
                var sut = new Table(3, 3, "A");

                var position = new CellPosition(1, 0);

                sut.UpdateRow(position, new[] { new Cell("X"), new Cell("Y") });

                Assert.That(sut.GetCell(new CellPosition(0, 0)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(1, 0)).Value, Is.EqualTo("X"));
                Assert.That(sut.GetCell(new CellPosition(2, 0)).Value, Is.EqualTo("Y"));

                Assert.That(sut.GetCell(new CellPosition(0, 1)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(1, 1)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(2, 1)).Value, Is.EqualTo("A"));

                Assert.That(sut.GetCell(new CellPosition(0, 2)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(1, 2)).Value, Is.EqualTo("A"));
                Assert.That(sut.GetCell(new CellPosition(2, 2)).Value, Is.EqualTo("A"));
            }
        }

        [TestFixture]
        public class GetRow : TableTests
        {
            [Test]
            public void WhenRowPositionLessThanZero_ThenThrowException()
            {
                var sut = new Table(1, 2, "A");

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetRow(-1));
            }

            [Test]
            public void WhenRowPositionGreaterOrEqualRows_ThenThrowException()
            {
                var sut = new Table(1, 2, "A");

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetRow(2));
            }

            [Test]
            public void WhenValidRowPosition_ThenReturnRow()
            {
                // A A A
                // X Y Z

                var sut = new Table(3, 2, "A");

                sut.UpdateRow(new CellPosition(0, 1), new []{ new Cell("X"), new Cell("Y"), new Cell("Z") });

                var result = sut.GetRow(1);

                Assert.That(result.First().Value, Is.EqualTo("X"));
                Assert.That(result.Second().Value, Is.EqualTo("Y"));
                Assert.That(result.Third().Value, Is.EqualTo("Z"));
            }
        }

        [TestFixture]
        public class GetColumn : TableTests
        {
            [Test]
            public void WhenColumnPositionLessThanZero_ThenThrowException()
            {
                var sut = new Table(1, 2, "A");

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetColumn(-1));
            }

            [Test]
            public void WhenColumnPositionGreaterOrEqualRows_ThenThrowException()
            {
                var sut = new Table(1, 2, "A");

                Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetColumn(2));
            }

            [Test]
            public void WhenValidColumnPosition_ThenReturnColumn()
            {
                // A A A
                // X Y Z

                var sut = new Table(3, 2, "A");

                sut.UpdateRow(new CellPosition(0, 1), new[] { new Cell("X"), new Cell("Y"), new Cell("Z") });

                var result = sut.GetColumn(1);

                Assert.That(result.First().Value, Is.EqualTo("A"));
                Assert.That(result.Second().Value, Is.EqualTo("Y"));
            }
        }
    }
}