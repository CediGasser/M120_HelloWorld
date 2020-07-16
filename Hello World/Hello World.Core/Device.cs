using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Core
{
    public class Device : FodyNotifyPropertyChangedBase
    {
        public Device(string name, int baseHelloWorldPerSecond, int cost)
        {
            this.Name = name;
            this.BaseHelloWorldPerSecond = baseHelloWorldPerSecond;
            this.Cost = cost;
        }

        public Device()
        {
        }

        public string Name { get; set; }

        public int Count { get; set; }

        public void IncreaseCountByOne()
        {
            this.Count++;
        }

        public int HelloWorldPerSecond => this.BaseHelloWorldPerSecond * Count;

        public int BaseHelloWorldPerSecond { get; }

        public int Cost { get; set; }
    }
}
