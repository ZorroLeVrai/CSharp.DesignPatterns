using Xunit;

namespace DesignPattern.Creational;

/// <summary>
/// Abstract Factory lets you produce families of related objects without specifying their concrete classes
/// </summary>
public interface IAbstractFactory
{
    IAFProductA CreateProductA();

    IAFProductB CreateProductB();
}

public class SmallFactory : IAbstractFactory
{
    public IAFProductA CreateProductA()
        => new AFSmallProductA();

    public IAFProductB CreateProductB()
        => new AFSmallProductB();
}

public class LargeFactory : IAbstractFactory
{
    public IAFProductA CreateProductA()
        => new AFLargeProductA();

    public IAFProductB CreateProductB()
        => new AFLargeProductB();
}

public interface IAFProductA
{
    string Name { get; }
}

public class AFSmallProductA : IAFProductA
{
    public string Name => "Small Product A";
}

public class AFLargeProductA : IAFProductA
{
    public string Name => "Large Product A";
}

public interface IAFProductB
{
    string Name { get; }
}

public class AFSmallProductB : IAFProductB
{
    public string Name => "Small Product B";
}

public class AFLargeProductB : IAFProductB
{
    public string Name => "Large Product B";
}

public class AbstractFactoryClient : AbstractRunner
{
    public override void Run()
    {
        var factory = new LargeFactory();
        IAFProductA productA = factory.CreateProductA();
        IAFProductB productB = factory.CreateProductB();

        Assert.Equal(productA.Name, "Large Product A");
        Assert.Equal(productB.Name, "Large Product B");
    }
}