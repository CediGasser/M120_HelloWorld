using System;
using System.Collections.Generic;


namespace Hello_World.Core.Device_Factory
{
    class DeviceFactory
    {
        private List<Device> helloWorldProducers = new List<Device>();

        public DeviceFactory()
        {
            CreateDevice();
        }

        public List<Device> HelloWorldProducers
        {
            get => helloWorldProducers;
            set => helloWorldProducers = value;
        }

        public void CreateDevice()
        {
            HelloWorldProducers.Add(new Device("Nokia", 1, 10));
            HelloWorldProducers.Add(new Device("BBZW Sursee Schüler PC", 3, 30));
            HelloWorldProducers.Add(new Device("Smart WC-Brille", 10, 100));
            HelloWorldProducers.Add(new Device("Elektro-Zahnbürste", 30, 300));
            HelloWorldProducers.Add(new Device("Smart Fridge", 100, 10000));
            HelloWorldProducers.Add(new Device("Airpods", 500, 5000));
            HelloWorldProducers.Add(new Device("VR Sonnenbrille", 1000, 10000));
            HelloWorldProducers.Add(new Device("Auto-Navi", 4500, 45000));
            HelloWorldProducers.Add(new Device("IPhone Note X MAX XS Plus", 10000, 100000));
            HelloWorldProducers.Add(new Device("Höllenmaschine", 50000, 500000));
            HelloWorldProducers.Add(new Device("Kaufmanns C++ Experten PC", 200000, 2000000));
            HelloWorldProducers.Add(new Device("CIA Spionagecomputer", 800000, 8000000));
            HelloWorldProducers.Add(new Device("E.D.I.T.H", 1300000, 13000000));
            HelloWorldProducers.Add(new Device("X AE A-XII", 2000000, 20000000));
            HelloWorldProducers.Add(new Device("NASA Super Computer", 6900000, 69000000));
        }
    }
}
