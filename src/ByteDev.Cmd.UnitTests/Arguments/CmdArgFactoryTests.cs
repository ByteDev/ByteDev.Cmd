using System;
using System.Collections.Generic;
using System.Linq;
using ByteDev.Cmd.Arguments;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Arguments
{
    [TestFixture]
    public class CmdArgFactoryTests
    {
        [TestFixture]
        public class Constructor : CmdArgFactoryTests
        {
            [Test]
            public void WhenAllowedArgsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => new CmdArgFactory(null));
            }
        }

        [TestFixture]
        public class Create : CmdArgFactoryTests
        {
            private CmdArgFactory _sut;

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

            [SetUp]
            public void SetUp()
            {
                _sut = new CmdArgFactory(new List<CmdAllowedArg>
                {
                    _allowedPathArg, _allowedAllFilesArg
                });
            }

            [Test]
            public void WhenNoAllowedArgs_ThenThrowException()
            {
                var sut = new CmdArgFactory(Enumerable.Empty<CmdAllowedArg>());

                var ex = Assert.Throws<CmdArgException>(() => sut.Create("d", @"C:\"));
                Assert.That(ex.Message, Is.EqualTo("Argument name: 'd' is not allowed."));
            }

            [Test]
            public void WhenArgNameIsNotAllowed_ThenThrowException()
            {
                var ex = Assert.Throws<CmdArgException>(() => _sut.Create("d", @"C:\"));
                Assert.That(ex.Message, Is.EqualTo("Argument name: 'd' is not allowed."));
            }

            [Test]
            public void WhenArgNameMatchesShortName_ThenReturnObject()
            {
                const string value = @"C:\somewhere";

                var result = _sut.Create(_allowedPathArg.ShortName, value);

                Assert.That(result.Value, Is.EqualTo(value));
                Assert.That(result.ShortName, Is.EqualTo(_allowedPathArg.ShortName));
                Assert.That(result.LongName, Is.EqualTo(_allowedPathArg.LongName));
                Assert.That(result.Description, Is.EqualTo(_allowedPathArg.Description));
                Assert.That(result.HasValue, Is.EqualTo(_allowedPathArg.HasValue));
            }

            [Test]
            public void WhenArgNameMatchesLongName_ThenReturnObject()
            {
                const string value = @"C:\somewhere";

                var result = _sut.Create(_allowedPathArg.LongName, value);

                Assert.That(result.Value, Is.EqualTo(value));
                Assert.That(result.ShortName, Is.EqualTo(_allowedPathArg.ShortName));
                Assert.That(result.LongName, Is.EqualTo(_allowedPathArg.LongName));
                Assert.That(result.Description, Is.EqualTo(_allowedPathArg.Description));
                Assert.That(result.HasValue, Is.EqualTo(_allowedPathArg.HasValue));
            }
        }
    }
}