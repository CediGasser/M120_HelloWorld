using System;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace Hello_World.Core.Test
{
    public class GameTest
    {
        class FakeDatetimeNowProvider : DatetimeNowProvider
        {
            public FakeDatetimeNowProvider(DateTime fakeNow)
            {
                this.FakeNow = fakeNow;
            }

            public void IncrementSeconds(int seconds)
            {
                this.FakeNow = this.FakeNow + TimeSpan.FromSeconds(seconds);
            }

            public DateTime FakeNow { get; set; }
        
            public override DateTime Now => FakeNow;
        }

        [Fact]
        public void TryBuyHelloWorldProducer_WhenEnoughKarma_ThenHelloWorldProducerIsBoughtAndKarmaSpent()
        {
            FakeDatetimeNowProvider nowProvider = new FakeDatetimeNowProvider(new DateTime(2020, 02, 02));

            IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o=>o.Strict());
            Game game = new Game(nowProvider, fakeErrorMessageDisplayer);

            Device deviceCosting500 = new Device("name", 10, 500);
            game.HelloWorldProducers.Add(deviceCosting500);
            game.Karma = 600;

            nowProvider.IncrementSeconds(1);
            game.TryBuyHelloWorldProducer(deviceCosting500);

            deviceCosting500.Count.Should().Be(1);
            game.Karma.Should().Be(100);
        }

        [Fact]
        public void UpdateKarma_WhenOneSecondPassed_ThenKarmaIsCorrectlyUpdated()
        {
            var nowProvider = new FakeDatetimeNowProvider(new DateTime(2020, 02, 02)); 
            IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());
            Game game = new Game(nowProvider, fakeErrorMessageDisplayer);

            Device deviceProducing100KarmaPerSecond = new Device("name", 100, 0);
            game.HelloWorldProducers.Add(deviceProducing100KarmaPerSecond);
            game.Karma = 100;
            game.TryBuyHelloWorldProducer(deviceProducing100KarmaPerSecond);

            nowProvider.IncrementSeconds(1);
            game.UpdateKarma();

            game.Karma.Should().Be(200);
        }

        [Fact]
        public void TryBuyHelloWorldProducer_WhenNotEnoughKarma_ThenHelloWorldProducerIsNotBoughtAndKarmaIsNotSpentAndExceptionIsThrown()
        {
            var nowProvider = new FakeDatetimeNowProvider(new DateTime(2020, 02, 02));
            IErrorMessageDisplayer fakeErrorMessageDisplayer = A.Fake<IErrorMessageDisplayer>(o => o.Strict());
            A.CallTo(() => fakeErrorMessageDisplayer.Show(A<string>._, A<string>._)).DoesNothing();

            Game testee = new Game(nowProvider, fakeErrorMessageDisplayer);

            Device deviceCosting500 = new Device("name", 10, 500);
            testee.HelloWorldProducers.Add(deviceCosting500);
            testee.Karma = 400;
            testee.TryBuyHelloWorldProducer(deviceCosting500);

            nowProvider.IncrementSeconds(1);

            A.CallTo(() => fakeErrorMessageDisplayer
                    .Show("Not enough Karma!", "You're poor haha!"))
                    .MustHaveHappened(1, Times.Exactly);
        }
    }
}