using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Core
{
    public class Device : IHelloWorldProducer
    {
        private readonly int baseHelloWorldPerSecond;

        public Device(string name, int baseHelloWorldPerSecond)
        {
            this.Name = name;
            this.baseHelloWorldPerSecond = baseHelloWorldPerSecond;
            this.Count++;
        }

        public string Name { get; }

        public int Count { get; set; }

        public int HelloWorldPerSecond => this.baseHelloWorldPerSecond * Count;


        public int Prize { get; set; }


    }
}
