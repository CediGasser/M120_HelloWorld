using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Hello_World.Core.Device_Factory;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        private readonly DatetimeNowProvider datetimeNowProvider;
        private readonly IErrorMessageDisplayer errorMessageDisplayer;
        private DateTime lastUpdate;
        private int karmaToAdd;

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

        public List<Device> HelloWorldProducers { get; private set; }

        public double Karma { get; set; }

        private void BuyHelloWorldProducer(Device helloWorldProducer)
        {
            this.UpdateKarma();
            helloWorldProducer.IncreaseCountByOne();
            this.karmaToAdd = this.CalculateAutomaticProducedHelloWorldPerSecond();
            this.Karma -= helloWorldProducer.Cost;
        }

        public void TryBuyHelloWorldProducer(Device helloWorldProducer)
        {
            if (helloWorldProducer.Cost <= this.Karma)
            {
                this.BuyHelloWorldProducer(helloWorldProducer);
            }
            else
            {
                this.errorMessageDisplayer.Show("Not enough Karma!", "You're poor haha!");
            }
        }
        
        public void UpdateKarma()
        {
            double secondsSinceLastUpdate = (this.datetimeNowProvider.Now - this.lastUpdate).TotalSeconds;
            this.Karma += this.karmaToAdd * secondsSinceLastUpdate;
            this.lastUpdate = this.datetimeNowProvider.Now;
        }

        private int CalculateAutomaticProducedHelloWorldPerSecond()
        {
            return this.HelloWorldProducers?.Select(device => device.HelloWorldPerSecond).Sum() ?? 0;
        }
    }

    public interface IErrorMessageDisplayer
    {
        void Show(string errorTitle, string errorMessage);
    }
}
