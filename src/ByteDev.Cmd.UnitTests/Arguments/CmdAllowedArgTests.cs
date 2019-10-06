using ByteDev.Cmd.Arguments;
using NUnit.Framework;

namespace ByteDev.Cmd.UnitTests.Arguments
{
    [TestFixture]
    public class CmdAllowedArgTests
    {
        [Test]
        public void WhenArgsValid_ThenSetProperties()
        {
            var sut = new CmdAllowedArg('p', true);

            Assert.That(sut.ShortName, Is.EqualTo('p'));
            Assert.That(sut.HasValue, Is.True);
        }
    }
}