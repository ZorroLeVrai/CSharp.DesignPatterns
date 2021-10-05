namespace DesignPattern.Creational
{
    //Abstract Factory lets you produce families of related objects without specifying their concrete classes.

    public interface IAbstractFactory
    {
        IAFProductA CreateProductA();

        IAFProductB CreateProductB();
    }

    public class SmallFactory : IAbstractFactory
    {
        IAFProductA IAbstractFactory.CreateProductA() => new AFSmallProductA();

        IAFProductB IAbstractFactory.CreateProductB() => new AFSmallProductB();
    }

    public class LargeFactory : IAbstractFactory
    {
        IAFProductA IAbstractFactory.CreateProductA() => new AFLargeProductA();

        IAFProductB IAbstractFactory.CreateProductB() => new AFLargeProductB();
    }

    public interface IAFProductA
    {}

    public class AFSmallProductA : IAFProductA
    {}

    public class AFLargeProductA : IAFProductA
    { }

    public interface IAFProductB
    { }

    public class AFSmallProductB : IAFProductB
    { }

    public class AFLargeProductB : IAFProductB
    { }
}
