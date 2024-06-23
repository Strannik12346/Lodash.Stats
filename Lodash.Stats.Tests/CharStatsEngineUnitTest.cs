using FluentAssertions;
using NUnit.Framework;

namespace Lodash.Stats.Tests
{
    public class CharStatsEngineUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestSimpleString_StatsShouldBe_CalculatedCorrectly()
        {
            var engine = new CharStatsEngine();

            engine.Add("abbcccdddd");

            var frequencies = engine.GetAllFrequencies();

            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'a', Frequency = 1 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'b', Frequency = 2 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'c', Frequency = 3 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'd', Frequency = 4 });
        }

        [Test]
        public void TestComplexString_StatsShouldBe_CalculatedCorrectly()
        {
            var engine = new CharStatsEngine();

            engine.Add(@"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt 
ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip 
ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla 
pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum");

            var frequencies = engine.GetAllFrequencies();

            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 's', Frequency = 18 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 't', Frequency = 32 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'r', Frequency = 22 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'i', Frequency = 42 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'n', Frequency = 24 });
            frequencies.Should().Contain(new CharStatsEngine.CharFrequency() { Char = 'g', Frequency = 3 });
        }
    }
}