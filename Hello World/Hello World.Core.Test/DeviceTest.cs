using FluentAssertions;
using Xunit;

namespace Hello_World.Core.Test
{
    public class DeviceTest
    {
        [Fact]
        public void IncreaseCountByOne_IncreasesCountByOne()
        {
            Device testee = new Device("SomeDevice", 1, 10);

            int originalCount = testee.Count;

            testee.IncreaseCountByOne();

            testee.Count.Should().Be(originalCount + 1);
        }
    }
}