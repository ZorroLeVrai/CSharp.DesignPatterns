using System;

namespace DesignPattern.Behavioural
{
    //Strategy lets you define a family of algorithms, put each of them into a separate class, and make their objects interchangeable.

    public interface IStrategy
    {
        void Exectute();
    }

    public class ConcreteStrategyAlpha : IStrategy
    {
        public void Exectute()
            => Console.WriteLine("Execute Strategy A");
    }

    public class ConcreteStrategyBeta : IStrategy
    {
        public void Exectute()
            => Console.WriteLine("Execute Strategy B");
    }

    public class StrategyContext
    {
        public IStrategy Strategy { get; set; }

        public StrategyContext(IStrategy strategy)
        {
            Strategy = strategy;
        }

        public void DoSomething()
            => Strategy.Exectute();
    }

    public class StrategyClient
    {
        public void UseStrategyPattern()
        {
            var context = new StrategyContext(new ConcreteStrategyAlpha());
            context.DoSomething();
            context = new StrategyContext(new ConcreteStrategyBeta());
            context.DoSomething();
        }
    }
}
