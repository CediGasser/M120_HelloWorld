using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Core
{
    class Device : IHelloWorldProducer
    {
        public Device(float baseHWps, string name)
        {
            BaseHWps = baseHWps;
            Name = name;
        }

        public string Name { get; }
        public int Count { get; set; }
        public int Prize { get; set; }
        public float HWps => BaseHWps * Count;
        public float BaseHWps { get; }
        public float UpgradeFactor { get; set; }

    }
}
