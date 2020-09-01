using System.Collections.Generic;

namespace Hello_World.Core.Device_Factory
{
    internal class DevicesFactory
    {
        public List<Device> CreateDefaultDevices()
        {
            return new List<Device>
            {
                new Device("Nokia", new Karma(0, 1), new Karma(0, 10)),
                new Device("BBZW Sursee Schüler PC", new Karma(0, 5), new Karma(0, 150)),
                new Device("Samsung Fridge", new Karma(0, 50), new Karma(0, 1000)),
                new Device("Roland Buchers Fachleiter Laptop", new Karma(0, 600), new Karma(0, 9000))
            };
        }
    }
}