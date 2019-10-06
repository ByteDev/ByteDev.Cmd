using System;
using System.Collections.Generic;
using System.Linq;
using ByteDev.Cmd.Arguments;
using ByteDev.Collections;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Arguments
{
    [TestFixture]
    public class CmdArgInfoTests
    {
        private readonly CmdAllowedArg _allowedPathArg = new CmdAllowedArg('p', true)
        {
            LongName = "path",
            Description = "Path to the file."
        };

        private readonly CmdAllowedArg _allowedAllFilesArg = new CmdAllowedArg('a', false)
        {
            LongName = "allfiles",
            Description = "Should use all files."
        };

        [TestFixture]
        public class Constructor : CmdArgInfoTests
        {
            [Test]
            public void WhenInputArgsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => new CmdArgInfo(null, new List<CmdAllowedArg>()));
            }

            [Test]
            public void WhenOneInputNameWithValue_ThenSetArguments()
            {
                const string value = @"C:\Temp";

                var sut = new CmdArgInfo(new[] { "-p", value }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.Single().Value, Is.EqualTo(value));

                AssertAreEqual(sut.Arguments.Single(), _allowedPathArg);
            }

            [Test]
            public void WhenOneInputNameWithNoValue_ThenSetArguments()
            {
                var sut = new CmdArgInfo(new[] { "-a" }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.Single().Value, Is.Null);

                AssertAreEqual(sut.Arguments.Single(), _allowedAllFilesArg);
            }

            [Test]
            public void WhenTwoInput_NoValueArgFirst_ThenSetArguments()
            {
                const string value = @"C:\Temp";

                var sut = new CmdArgInfo(new[] { "-a", "-p", value }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.Null);
                AssertAreEqual(sut.Arguments.First(), _allowedAllFilesArg);

                Assert.That(sut.Arguments.Second().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.Second(), _allowedPathArg);
            }

            [Test]
            public void WhenTwoInput_ValueArgFirst_ThenSetArguments()
            {
                const string value = @"C:\Temp";

                var sut = new CmdArgInfo(new[] { "-p", value, "-a" }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.First(), _allowedPathArg);

                Assert.That(sut.Arguments.Second().Value, Is.Null);
                AssertAreEqual(sut.Arguments.Second(), _allowedAllFilesArg);
            }
            
            [Test]
            public void WhenTwoLongInput_ValueArgFirst_ThenSetArguments()
            {
                const string value = @"C:\Temp";

                var sut = new CmdArgInfo(new[] { "-path", value, "-allfiles" }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.First(), _allowedPathArg);

                Assert.That(sut.Arguments.Second().Value, Is.Null);
                AssertAreEqual(sut.Arguments.Second(), _allowedAllFilesArg);
            }

            private static void AssertAreEqual(CmdArg cmdArg, CmdAllowedArg cmdAllowedArg)
            {
                Assert.That(cmdArg.ShortName, Is.EqualTo(cmdAllowedArg.ShortName));
                Assert.That(cmdArg.LongName, Is.EqualTo(cmdAllowedArg.LongName));
                Assert.That(cmdArg.Description, Is.EqualTo(cmdAllowedArg.Description));
                Assert.That(cmdArg.HasValue, Is.EqualTo(cmdAllowedArg.HasValue));
            }
        }

        [TestFixture]
        public class HelpText : CmdArgInfoTests
        {
            [Test]
            public void WhenNoAllowedArgs_ThenReturnEmpty()
            {
                var sut = new CmdArgInfo(new string[0], new List<CmdAllowedArg>());

                Assert.That(sut.HelpText, Is.Empty);
            }

            [Test]
            public void WhenTwoAllowedArgs_ThenReturnHelpText()
            {
                var padding = new string(' ', 5);

                string expected =
                    "-p       " + padding + "Path to the file.\r\n" +
                    "-path    " + padding + "Path to the file.\r\n" +
                    "-a       " + padding + "Should use all files.\r\n" +
                    "-allfiles" + padding + "Should use all files.\r\n";

                const string value = @"C:\Temp";

                var sut = new CmdArgInfo(new[] { "-p", value, "-a" }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.HelpText, Is.EqualTo(expected));
            }
        }
    }
}