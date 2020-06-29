using System;
using System.Collections.Generic;
using System.Diagnostics;
using Hello_World.Core.Device_Factory;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        private List<IHelloWorldProducer> helloWorldProducers = new List<IHelloWorldProducer>();

        public Game(int karma)
        {
            Karma = karma;
            DeviceFactory factory = new DeviceFactory();
            helloWorldProducers = factory.HelloWorldProducers;
        }
        
        public List<IHelloWorldProducer> HelloWorldProducers
        {
            get => helloWorldProducers;
        }

        public int Karma { get; set; }

        public void AddHelloWorldProducer(IHelloWorldProducer helloWorldProducer)
        {
            this.HelloWorldProducers.Add(helloWorldProducer);
        }
    }
}
