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

    public class AbstractFactoryClient
    {
        public void UseAbstractFactory()
        {
            var factory = new LargeFactory();
            IAFProductA productA = factory.CreateProductA();
            IAFProductB productB = factory.CreateProductB();
        }
    }
}