using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        private List<IHelloWorldProducer> helloWorldProducers = new List<IHelloWorldProducer>();

        public Game(int karma)
        {
            Karma = karma;
            this.helloWorldProducers.Add(new Device("lolz",3));
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
