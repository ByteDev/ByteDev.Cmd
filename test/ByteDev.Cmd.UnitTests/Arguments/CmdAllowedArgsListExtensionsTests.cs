using System;
using System.Collections.Generic;
using ByteDev.Cmd.Arguments;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Arguments
{
    [TestFixture]
    public class CmdAllowedArgsListExtensionsTests
    {
        [TestFixture]
        public class HelpText : CmdAllowedArgsListExtensionsTests
        {
            private const string Padding = "     ";

            private CmdAllowedArg _allowedPathArg;
            private CmdAllowedArg _allowedAllFilesArg;
            
            [SetUp]
            public void SetUp()
            {
                _allowedPathArg = new CmdAllowedArg('p', true)
                {
                    LongName = "path",
                    Description = "Path to the file."
                };

                _allowedAllFilesArg = new CmdAllowedArg('a', false)
                {
                    LongName = "allfiles",
                    Description = "Should use all files."
                };
            }

            [Test]
            public void WhenAllowedArgsIsNull_ThenThrowException()
            {
                IList<CmdAllowedArg> sut = null;

                Assert.Throws<ArgumentNullException>(() => sut.HelpText());
            }

            [Test]
            public void WhenNoAllowedArgs_ThenReturnEmpty()
            {
                var sut = new List<CmdAllowedArg>();

                var result = sut.HelpText();

                Assert.That(result, Is.Empty);
            }

            [Test]
            public void WhenTwoAllowedArgs_ThenReturnHelpText()
            {
                const string expected = "-p       " + Padding + "Path to the file.\r\n" +
                                        "-path    " + Padding + "Path to the file.\r\n" +
                                        "-a       " + Padding + "Should use all files.\r\n" +
                                        "-allfiles" + Padding + "Should use all files.\r\n";

                var sut = new List<CmdAllowedArg>  { _allowedPathArg, _allowedAllFilesArg };

                var result = sut.HelpText();

                Assert.That(result, Is.EqualTo(expected));
            }

            [Test]
            public void WhenAllowedArgsHasNoLongName_ThenReturnHelpText()
            {
                _allowedPathArg.LongName = null;
                _allowedAllFilesArg.LongName = null;

                const string expected = "-p" + Padding + "Path to the file.\r\n" +
                                        "-a" + Padding + "Should use all files.\r\n";

                    var sut = new List<CmdAllowedArg> { _allowedPathArg, _allowedAllFilesArg };

                var result = sut.HelpText();

                Assert.That(result, Is.EqualTo(expected));
            }
        }
    }
}
