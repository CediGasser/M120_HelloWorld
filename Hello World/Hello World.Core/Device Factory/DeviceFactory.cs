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
           HelloWorldProducers.Add(new Device("BBZW Sursee Schüler PC", 5, 150));
           HelloWorldProducers.Add(new Device("Samsung Fridge", 50, 1000));
           HelloWorldProducers.Add(new Device("Roland Buchers Fachleiter Laptop", 600, 9000));
        }
    }
}
