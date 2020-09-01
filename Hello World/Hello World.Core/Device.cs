namespace Hello_World.Core
{
    public class Device : FodyNotifyPropertyChangedBase
    {
        public Device(string name, Karma baseHelloWorldPerSecond, Karma cost)
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

        public Karma HelloWorldPerSecond => this.Count * this.BaseHelloWorldPerSecond;

        public Karma BaseHelloWorldPerSecond { get; }

        public Karma Cost { get; set; }

        public void IncreaseCountByOne()
        {
            this.Count++;
        }
    }
}