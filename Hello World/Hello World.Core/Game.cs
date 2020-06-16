using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hello_World.Core
{
    public class Game
    {
        public List<IHelloWorldProducer> HelloWorldProducers { get; set; }
        public List<IUpgrade> Upgrades { get; set; }


        public event EventHandler<IUpgrade> NotifyUpgrading;

        protected virtual void OnNotifyUpgrading(IUpgrade e)
        {
            NotifyUpgrading?.Invoke(this, e);
        }
    }
}
