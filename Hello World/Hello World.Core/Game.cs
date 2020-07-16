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
        private DateTime lastUpdate;
        private int karmaToAdd;

        public Game(DatetimeNowProvider datetimeNowProvider)
        {
            this.datetimeNowProvider = datetimeNowProvider;

            this.lastUpdate = datetimeNowProvider.Now;
            this.HelloWorldProducers = new DevicesFactory().CreateDefaultDevices();
        }
        
        public List<Device> HelloWorldProducers { get; private set; }

        public double Karma { get; set; }

        private void BuyHelloWorldProducer(Device helloWorldProducer)
        {
            UpdateKarma();
            helloWorldProducer.IncreaseCountByOne();
            this.karmaToAdd = CalculateAutomaticProducedHelloWorldPerSecond();
            this.Karma -= helloWorldProducer.Cost;
        }

        public void TryBuyHelloWorldProducer(Device helloWorldProducer)
        {
            if (helloWorldProducer.Cost <= Karma)
            {
                BuyHelloWorldProducer(helloWorldProducer);
            }
            else
            {
                throw new NotEnoughKarmaException();
            }
        }

        public void UpdateKarma()
        {
            double secondsSinceLastUpdate = (this.datetimeNowProvider.Now - this.lastUpdate).TotalSeconds;
            this.Karma = this.Karma + this.karmaToAdd * secondsSinceLastUpdate;
            this.lastUpdate = this.datetimeNowProvider.Now;
        }

        private int CalculateAutomaticProducedHelloWorldPerSecond()
        {
            return HelloWorldProducers?.Select(device => device.HelloWorldPerSecond).Sum() ?? 0;
        }
    }
}
