using System;
using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Hello_World.Core.Test
{
    public class GameTest
    {
        [Fact]
        public void TryBuyHelloWorldProducer_WhenEnoughKarma_ThenHelloWorldProducerIsBoughtAndKarmaSpent()
        {
            FakeDatetimeNowProvider nowProvider = new FakeDatetimeNowProvider(new DateTime(2020, 02, 02));

            IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());
            Game game = new Game(nowProvider, fakeErrorMessageDisplayer);

            Device deviceCosting500 = new Device("name", new Karma(0, 10), new Karma(0, 500));
            game.HelloWorldProducers.Add(deviceCosting500);
            game.Karma = new Karma(0, 600);
            nowProvider.IncrementSeconds(1);
            game.TryBuyHelloWorldProducer(deviceCosting500);
            Karma expectedKarma = new Karma(new List<long> {100});

            deviceCosting500.Count.Should().Be(1);
            game.Karma.Value.Should().BeEquivalentTo(expectedKarma.Value);
        }

        [Fact]
        public void
            TryBuyHelloWorldProducer_WhenNotEnoughKarma_ThenHelloWorldProducerIsNotBoughtAndKarmaIsNotSpentAndExceptionIsThrown()
        {
            FakeDatetimeNowProvider nowProvider = new FakeDatetimeNowProvider(new DateTime(2020, 02, 02));
            IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());
            A.CallTo(() => fakeErrorMessageDisplayer.Show(A<string>._, A<string>._)).DoesNothing();

            Game testee = new Game(nowProvider, fakeErrorMessageDisplayer);

            Device deviceCosting500 = new Device("name", new Karma(0, 10), new Karma(0, 500));
            testee.HelloWorldProducers.Add(deviceCosting500);
            testee.Karma = new Karma(0, 400);
            testee.TryBuyHelloWorldProducer(deviceCosting500);

            nowProvider.IncrementSeconds(1);

            A.CallTo(() => fakeErrorMessageDisplayer
                    .Show("Not enough Karma!", "You're poor haha!"))
                .MustHaveHappened(1, Times.Exactly);
        }

        [Fact]
        public void UpdateKarma_WhenOneSecondPassed_ThenKarmaIsCorrectlyUpdated()
        {
            FakeDatetimeNowProvider nowProvider = new FakeDatetimeNowProvider(new DateTime(2020, 02, 02));
            IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());
            Game game = new Game(nowProvider, fakeErrorMessageDisplayer);

            Device deviceProducing100KarmaPerSecond = new Device("name", new Karma(0, 100), new Karma(0, 0));
            game.HelloWorldProducers.Add(deviceProducing100KarmaPerSecond);
            game.Karma = new Karma(0, 100);
            game.TryBuyHelloWorldProducer(deviceProducing100KarmaPerSecond);

            nowProvider.IncrementSeconds(1);
            game.UpdateKarma();

            Karma expectedKarma = new Karma(new List<long> {200});

            game.Karma.Value.Should().BeEquivalentTo(expectedKarma.Value);
        }

        private class FakeDatetimeNowProvider : DatetimeNowProvider
        {
            public FakeDatetimeNowProvider(DateTime fakeNow)
            {
                this.FakeNow = fakeNow;
            }

            private DateTime FakeNow { get; set; }

            public override DateTime Now => this.FakeNow;

            public void IncrementSeconds(int seconds)
            {
                this.FakeNow += TimeSpan.FromSeconds(seconds);
            }
        }
    }
}