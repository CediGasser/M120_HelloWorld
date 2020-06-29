using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Core
{
    public class Device
    {
        private readonly int baseHelloWorldPerSecond;
        
        public Device(string name, int baseHelloWorldPerSecond, int prize)
        {
            this.Name = name;
            this.baseHelloWorldPerSecond = baseHelloWorldPerSecond;
            this.Prize = prize;
        }

        public Device()
        {
            
        }

        public string Name { get; }

        public int Count { get; set; }

        public void AddToCount()
        {
            this.Count++;
        }

        public int HelloWorldPerSecond => this.baseHelloWorldPerSecond * Count;

        public int BaseHelloWorldPerSecond => baseHelloWorldPerSecond;

        public int Prize { get; set; }


    }
}
