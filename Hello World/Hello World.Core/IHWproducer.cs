namespace Hello_World.Core
{
    public interface IHelloWorldProducer
    {
        string Name { get; }
        int Prize { get; set; }
        int Count { get; set; }
        float HWps { get; }
        float BaseHWps { get; }
    }
}