using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hello_World.Core
{
    public class Game : FodyNotifyPropertyChangedBase
    {
        private List<IHelloWorldProducer> helloWorldProducers = new List<IHelloWorldProducer>();

        public Game()
        {
            Karma = 0;
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
