using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Hello_World.Core.Test
{
    public class KarmaTest
    {
        [Fact]
        public void TestKarma()
        {
            Karma currentKarma = new Karma(1,8); //Saves number {8} at power {1}
            const int secondsPassed = 10;
            Karma newKarma = currentKarma + secondsPassed 
                * (
                    new Karma(0, 10) 
                    + new Karma(0, 5) 
                    + new Karma(1, 10)
                    );
            Karma expectedKarma = new Karma(new List<long>() {150, 108});

            newKarma.Value.Should().BeEquivalentTo(expectedKarma.Value);
        }

        [Fact]
        public void TestKarmaBig()
        {
            Karma currentKarma = new Karma(1, 8); 
            const int secondsPassed = 100;
            Karma newKarma = currentKarma + secondsPassed 
                * (
                    new Karma(0, 15_000) 
                    + new Karma(0, 5) 
                    + new Karma(1, 34_000)
                    );
            Karma expectedKarma = new Karma(new List<long>() { 500_500, 400_009,3 });

            newKarma.Value.Should().BeEquivalentTo(expectedKarma.Value);
        }

        [Fact]
        public void TestKarmaVerrryBig()
        {
            Karma newKarma = new Karma(0, 1_500_000) + new Karma(0, 5_000_000_000_000) + new Karma(1, 3_400_000);
            List<long> expectedKarma = new List<long>() { 500_000, 400_001, 8 };

            newKarma.Value.Should().BeEquivalentTo(expectedKarma);
        }

        [Fact]
        public void TestKarmaVerrryVerrryBig()
        {
            Karma newKarma = new Karma(0, 1_500_000) + new Karma(0, 5_000_000_000_000_000_000) + new Karma(1, 3_400_000);
            List<long> expectedKarma = new List<long>() { 500_000, 400_001, 3, 5 };

            newKarma.Value.Should().BeEquivalentTo(expectedKarma);
        }
    }
}