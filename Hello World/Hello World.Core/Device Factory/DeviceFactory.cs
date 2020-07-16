using System;
using System.Collections.Generic;


namespace Hello_World.Core.Device_Factory
{
    class DevicesFactory
    {
        public List<Device> CreateDefaultDevices()
        {
            return  new List<Device>
            {
                new Device("Nokia", 1, 10),
                new Device("BBZW Sursee Schüler PC", 5, 150),
                new Device("Samsung Fridge", 50, 1000),
                new Device("Roland Buchers Fachleiter Laptop", 600, 9000)
            };
        }
    }
}
