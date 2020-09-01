using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Hello_World.Core.Test
{
    public class KarmaTest
    {
        [Fact]
        public void TestKarmaMultiplieAndAdd()
        {
            Karma currentKarma = new Karma(1, 8);
            const int secondsPassed = 10;
            Karma newKarma = currentKarma + secondsPassed
                * (
                    new Karma(0, 10)
                    + new Karma(0, 5)
                    + new Karma(1, 10)
                );
            Karma expectedKarma = new Karma(new List<long> {150, 108});

            newKarma.Value.Should().BeEquivalentTo(expectedKarma.Value);
        }

        [Fact]
        public void TestKarmaMultiplieAndAddWithBigValues()
        {
            Karma currentKarma = new Karma(1, 8);
            const int secondsPassed = 100;
            Karma newKarma = currentKarma + secondsPassed
                * (
                    new Karma(0, 15_000)
                    + new Karma(0, 5)
                    + new Karma(1, 34_000)
                );
            Karma expectedKarma = new Karma(new List<long> {500_500, 400_009, 3});

            newKarma.Value.Should().BeEquivalentTo(expectedKarma.Value);
        }

        [Fact]
        public void TestKarmaMultiplieAndAddWithBiggerValues()
        {
            Karma newKarma = new Karma(0, 1_500_000) + new Karma(0, 5_000_000_000_000) + new Karma(1, 3_400_000);
            List<long> expectedKarma = new List<long> {500_000, 400_001, 8};

            newKarma.Value.Should().BeEquivalentTo(expectedKarma);
        }

        [Fact]
        public void TestKarmaMultiplieAndAddWithBiggestValues()
        {
            Karma newKarma = new Karma(0, 1_500_000) + new Karma(0, 5_000_000_000_000_000_000) + new Karma(1, 3_400_000);
            List<long> expectedKarma = new List<long> {500_000, 400_001, 3, 5};

            newKarma.Value.Should().BeEquivalentTo(expectedKarma);
        }

        [Fact]
        public void TestKarmaMinusSimple()
        {
            Karma minuend = new Karma(0, 500_000);
            Karma subtrahend = new Karma(0, 140_000);
            Karma ergebnis = minuend - subtrahend;

            List<long> expectedKarma = new List<long> {360_000 };

            ergebnis.Value.Should().BeEquivalentTo(expectedKarma);
        }

        [Fact]
        public void TestKarmaMinusNotSimple()
        {
            Karma minuend = new Karma(1, 5);
            Karma subtrahend = new Karma(0, 100_000);
            Karma ergebnis = minuend - subtrahend;

            List<long> expectedKarma = new List<long> { 900_000,4 };

            ergebnis.Value.Should().BeEquivalentTo(expectedKarma);
        }

        [Fact]
        public void TestKarmaMinusNotSimpleAndBig()
        {
            Karma minuend = new Karma(1, 5);
            Karma subtrahend = new Karma(0, 10_100_000);
            Karma ergebnis = minuend - subtrahend;

            List<long> expectedKarma = new List<long> { 900_000, 999_994,-1 };

            ergebnis.Value.Should().BeEquivalentTo(expectedKarma);
        }
    }
}