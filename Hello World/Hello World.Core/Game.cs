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
        private DateTime lastUpdate;
        private int karmaToAdd;

        public Game()
        {
            this.HelloWorldProducers = new DevicesFactory().CreateDefaultDevices();
        }
        
        public List<Device> HelloWorldProducers { get; private set; }

        public double Karma { get; set; }

        private void BuyHelloWorldProducer(Device helloWorldProducer)
        {
            this.karmaToAdd = CalculateAutomaticProducedHelloWorldPerSecond();
            UpdateKarma();
            helloWorldProducer.AddToCount();
        }

        public void TryBuyHelloWorldProducer(Device helloWorldProducer)
        {
            if (helloWorldProducer.Prize <= Karma)
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
            double secondsSinceLastUpdate = (DateTime.Now - lastUpdate).TotalSeconds;
            double huii = this.Karma + karmaToAdd * secondsSinceLastUpdate;
            this.Karma = huii;
            this.lastUpdate = DateTime.Now;
        }

        private int CalculateAutomaticProducedHelloWorldPerSecond()
        {
            return HelloWorldProducers?.Select(device => device.HelloWorldPerSecond).Sum() ?? 0;
        }
    }
}
