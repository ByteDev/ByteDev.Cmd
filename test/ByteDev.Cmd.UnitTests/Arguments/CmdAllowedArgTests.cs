using System;
using ByteDev.Cmd.Arguments;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Arguments
{
    [TestFixture]
    public class CmdAllowedArgTests
    {
        [TestFixture]
        public class Constructor : CmdAllowedArgTests
        {
            [TestCase('A')]
            [TestCase('Z')]
            [TestCase('a')]
            [TestCase('z')]
            public void WhenShortNameValid_ThenSetProperties(char shortName)
            {
                var sut = new CmdAllowedArg(shortName, true);

                Assert.That(sut.ShortName, Is.EqualTo(shortName));
                Assert.That(sut.HasValue, Is.True);
            }

            [TestCase('0')]
            [TestCase('-')]
            public void WhenShortNameIsNotValid_ThenThrowException(char shortName)
            {
                Assert.Throws<ArgumentException>(() => _ = new CmdAllowedArg(shortName, false));
            }
        }

        [TestFixture]
        public class LongName : CmdAllowedArgTests
        {
            [TestCase(null)]
            [TestCase("A")]
            [TestCase("a")]
            [TestCase("abc")]
            public void WhenContainsValidChars_ThenSet(string longName)
            {
                var sut = new CmdAllowedArg('a', false) { LongName = longName };

                Assert.That(sut.LongName, Is.EqualTo(longName));
            }

            [TestCase("")]
            [TestCase("-a")]
            [TestCase("a1")]
            public void WhenContainsInvalidChars_ThenThrowException(string longName)
            {
                Assert.Throws<ArgumentException>(() => _ = new CmdAllowedArg('a', false) { LongName = longName });
            }
        }
    }
}