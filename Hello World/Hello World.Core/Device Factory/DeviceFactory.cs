using System;
using System.Collections.Generic;


namespace Hello_World.Core.Device_Factory
{
    class DeviceFactory
    {
        private List<IHelloWorldProducer> helloWorldProducers = new List<IHelloWorldProducer>();

        public DeviceFactory()
        {
            CreateDevice();
        }

        public List<IHelloWorldProducer> HelloWorldProducers
        {
            get => helloWorldProducers;
            set => helloWorldProducers = value;
        }

        public void CreateDevice()
        {
           HelloWorldProducers.Add(new Device("Nyffis Power PC", 13, 600));
           HelloWorldProducers.Add(new Device("BBZW Sursee Schüler PC", 1, 10));
           HelloWorldProducers.Add(new Device("Roland Buchers God Of Sursee Laptop", 100, 1000));
           HelloWorldProducers.Add(new Device("Burgers Salsa Boom Box", 5, 10000));
        }
    }
}
