using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_World.Core
{
    class Device : IHelloWorldProducer
    {
        public Device(Game game, float baseHWps, string name)
        {
            BaseHWps = baseHWps;
            Name = name;
            game.NotifyUpgrading += this.OnNotifyUpgrading;
        }

        public string Name { get; }
        public int Count { get; set; }
        public int Prize { get; set; }
        public float HWps => BaseHWps*Count;
        public float BaseHWps { get; }
        public float UpgradeFactor { get; set; }

        public virtual void OnNotifyUpgrading(object sender, IUpgrade upgrade)
        {

        }

    }

    class Supercomputer : Device
    {
        public Supercomputer(Game game, float baseHWps, string name) : base(game, baseHWps, name)
        {
        }

        public override void OnNotifyUpgrading(object sender, IUpgrade upgrade)
        {

            base.OnNotifyUpgrading(sender, upgrade);
        }
    }
}
