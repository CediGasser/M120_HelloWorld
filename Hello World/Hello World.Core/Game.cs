using System;
using System.Collections.Generic;
using Hello_World.Core.Device_Factory;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        private readonly DatetimeNowProvider datetimeNowProvider;
        private readonly IErrorMessageDisplayer errorMessageDisplayer;
        private Karma karmaToAdd = new Karma(0, 0);
        private DateTime lastUpdate;

        public Game(DatetimeNowProvider datetimeNowProvider, IErrorMessageDisplayer errorMessageDisplayer)
        {
            this.datetimeNowProvider = datetimeNowProvider;
            this.errorMessageDisplayer = errorMessageDisplayer;

            this.lastUpdate = datetimeNowProvider.Now;
            this.HelloWorldProducers = new DevicesFactory().CreateDefaultDevices();
        }

        public Game()
        {
        }

        public List<Device> HelloWorldProducers { get; }

        public Karma Karma { get; set; } = new Karma(0,0);

        private void BuyHelloWorldProducer(Device helloWorldProducer)
        {
            this.UpdateKarma();
            helloWorldProducer.IncreaseCountByOne();
            this.karmaToAdd = this.CalculateAutomaticProducedHelloWorldPerSecond();
            this.Karma -= helloWorldProducer.Cost;
        }

        public void TryBuyHelloWorldProducer(Device helloWorldProducer)
        {
            if (helloWorldProducer.Cost < this.Karma)
                this.BuyHelloWorldProducer(helloWorldProducer);
            else
                this.errorMessageDisplayer.Show("Not enough Karma!", "You're poor haha!");
        }

        public void UpdateKarma()
        {
            double secondsSinceLastUpdate = (this.datetimeNowProvider.Now - this.lastUpdate).TotalSeconds;
            this.Karma += Convert.ToInt32(secondsSinceLastUpdate) * this.karmaToAdd;
            this.lastUpdate = this.datetimeNowProvider.Now;
        }

        private Karma CalculateAutomaticProducedHelloWorldPerSecond()
        {
            Karma karmaPerSecond = new Karma(0, 0);
            if (this.HelloWorldProducers != null)
                foreach (Device helloWorldProducer in this.HelloWorldProducers)
                    karmaPerSecond += helloWorldProducer.HelloWorldPerSecond;

            return karmaPerSecond;
        }
    }

    public interface IErrorMessageDisplayer
    {
        void Show(string errorTitle, string errorMessage);
    }
}