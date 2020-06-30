using System;
using System.Collections.Generic;
using System.Diagnostics;
using Hello_World.Core.Device_Factory;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        public Game()
        {
            DeviceFactory factory = new DeviceFactory();
            HelloWorldProducers = factory.HelloWorldProducers;
            Karma = 0;
        }
        
        public List<Device> HelloWorldProducers { get; set; }

        public long Karma { get; set; }

        public void AddHelloWorldProducer(Device helloWorldProducer)
        {
            this.HelloWorldProducers.Add(helloWorldProducer);
        }
    }
}
