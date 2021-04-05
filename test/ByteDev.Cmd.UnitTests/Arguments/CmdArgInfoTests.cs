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
        private const string value = @"C:\Temp";

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

        [TestFixture]
        public class Constructor : CmdArgInfoTests
        {
            [Test]
            public void WhenInputArgsIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentNullException>(() => _ = new CmdArgInfo(null, new List<CmdAllowedArg>()));
            }

            [Test]
            public void WhenOneInputNameWithValue_ThenSetArguments()
            {
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
                var sut = new CmdArgInfo(new[] { "-a", "-p", value }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.Null);
                AssertAreEqual(sut.Arguments.First(), _allowedAllFilesArg);

                Assert.That(sut.Arguments.Second().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.Second(), _allowedPathArg);
            }

            [Test]
            public void WhenTwoInput_ValueArgFirst_ThenSetArguments()
            {
                var sut = new CmdArgInfo(new[] { "-p", value, "-a" }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.First(), _allowedPathArg);

                Assert.That(sut.Arguments.Second().Value, Is.Null);
                AssertAreEqual(sut.Arguments.Second(), _allowedAllFilesArg);
            }
            
            [Test]
            public void WhenTwoLongInput_ValueArgFirst_ThenSetArguments()
            {
                var sut = new CmdArgInfo(new[] { "-path", value, "-allfiles" }, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.First(), _allowedPathArg);

                Assert.That(sut.Arguments.Second().Value, Is.Null);
                AssertAreEqual(sut.Arguments.Second(), _allowedAllFilesArg);
            }


            [Test]
            public void WhenOneArgIsRequiredAndNotPresent_ThenThrowException()
            {
                _allowedPathArg.IsRequired = true;

                var args = new[] { "-a" };

                var ex = Assert.Throws<CmdArgException>(() => _ = new CmdArgInfo(args, new[] { _allowedPathArg, _allowedAllFilesArg }));
                Assert.That(ex.Message, Is.EqualTo($"Argument '{_allowedPathArg.ShortName}' is required and not supplied."));
            }

            [Test]
            public void WhenTwoArgIsRequiredAndNotPresent_ThenThrowException()
            {
                _allowedPathArg.IsRequired = true;
                _allowedAllFilesArg.IsRequired = true;

                var args = new string[0];

                var ex = Assert.Throws<CmdArgException>(() => _ = new CmdArgInfo(args, new[] { _allowedPathArg, _allowedAllFilesArg }));

                var expectedMessage =
                    $"Argument '{_allowedPathArg.ShortName}' is required and not supplied." + Environment.NewLine +
                    $"Argument '{_allowedAllFilesArg.ShortName}' is required and not supplied.";

                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }

            [Test]
            public void WhenTwoArgIsRequiredAndThreeSupplied_ThenThrowException()   // aka same arg supplied more than once
            {
                var args = new[] {"-p", value, "-a", "-a"};

                var ex = Assert.Throws<CmdArgException>(() => _ = new CmdArgInfo(args, new[] { _allowedPathArg, _allowedAllFilesArg }));
                Assert.That(ex.Message, Is.EqualTo("Allowed arguments 2 but 3 provided (p, a, a)."));
            }

            [Test]
            public void WhenTwoArgsIsRequired_AndAreBothPresent_ThenSetArguments()
            {
                _allowedPathArg.IsRequired = true;
                _allowedAllFilesArg.IsRequired = true;

                var args = new[] { "-p", value, "-a" };

                var sut = new CmdArgInfo(args, new[] { _allowedPathArg, _allowedAllFilesArg });

                Assert.That(sut.Arguments.First().Value, Is.EqualTo(value));
                AssertAreEqual(sut.Arguments.First(), _allowedPathArg);

                Assert.That(sut.Arguments.Second().Value, Is.Null);
                AssertAreEqual(sut.Arguments.Second(), _allowedAllFilesArg);
            }

            [Test]
            public void WhenArgNameHasTrailingSpace_ThenThrowException()
            {
                var args = new[] { "-a " };

                var ex = Assert.Throws<CmdArgException>(() => _ = new CmdArgInfo(args, new[] { _allowedAllFilesArg }));
                Assert.That(ex.Message, Is.EqualTo("Argument name: 'a ' is not allowed."));
            }

            [Test]
            public void WhenArgValidHasTrailingSpace_ThenKeepTrailingSpace()
            {
                var args = new[] { "-p", "Something " };

                var sut = new CmdArgInfo(args, new[] { _allowedPathArg });

                Assert.That(sut.Arguments.Single().ShortName, Is.EqualTo('p'));
                Assert.That(sut.Arguments.Single().Value, Is.EqualTo("Something "));
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
        public class HasArgument_ShortName : CmdArgInfoTests
        {
            [Test]
            public void WhenArgumentNotPresent_ThenReturnFalse()
            {
                var args = new[] { "-p", value };

                var sut = new CmdArgInfo(args, new[] { _allowedPathArg, _allowedAllFilesArg });

                var result = sut.HasArgument('a');

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenArgumentPresent_ThenReturnTrue()
            {
                var args = new[] { "-a" };

                var sut = new CmdArgInfo(args, new[] { _allowedAllFilesArg });

                var result = sut.HasArgument('a');

                Assert.That(result, Is.True);
            }
        }

        [TestFixture]
        public class HasArgument_LongName : CmdArgInfoTests
        {
            [Test]
            public void WhenArgumentNotPresent_ThenReturnFalse()
            {
                var args = new[] { "-p", value };

                var sut = new CmdArgInfo(args, new[] { _allowedPathArg, _allowedAllFilesArg });

                var result = sut.HasArgument("allfiles");

                Assert.That(result, Is.False);
            }

            [Test]
            public void WhenArgumentPresent_ThenReturnTrue()
            {
                var args = new[] { "-a" };

                var sut = new CmdArgInfo(args, new[] { _allowedAllFilesArg });

                var result = sut.HasArgument("allfiles");

                Assert.That(result, Is.True);
            }
        }
    }
}