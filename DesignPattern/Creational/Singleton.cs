using Xunit;

namespace DesignPattern.Creational;

/// <summary>
/// The Singleton patten ensures that a class has only one instance
/// </summary>
public sealed class Singleton
{
    private static readonly Singleton _instance = new();

    private Singleton()
    { }

    public static Singleton Instance
    {
        get => _instance;
    }
}

public class SingletonClient : AbstractRunner
{
    public override void Run()
    {
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;
        Assert.Equal(instance1, instance2);
    }
}
