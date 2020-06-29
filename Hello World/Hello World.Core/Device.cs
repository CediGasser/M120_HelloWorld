using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Core
{
    public class Device
    {
        public Device(string name, int baseHelloWorldPerSecond, int prize)
        {
            this.Name = name;
            this.BaseHelloWorldPerSecond = baseHelloWorldPerSecond;
            this.Prize = prize;
        }

        public Device()
        {
            
        }

        public string Name { get; set; }

        public int Count { get; set; }

        public void AddToCount()
        {
            this.Count++;
        }

        public int HelloWorldPerSecond => this.BaseHelloWorldPerSecond * Count;

        public int BaseHelloWorldPerSecond { get; set; }

        public int Prize { get; set; }


    }
}
