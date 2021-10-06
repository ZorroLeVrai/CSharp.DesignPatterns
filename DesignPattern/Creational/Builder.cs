using System;

namespace DesignPattern.Creational
{
    //Builder lets you construct complex objects step by step.
    //The pattern allows you to produce different types and representations of an object using the same construction code.

    public interface IBuilder
    {
        IBProduct Product { get; }

        void Reset();
        void BuildStepA();
        void BuildStepB();
        void BuildStepC();
    }

    public class BuilderAlpha : IBuilder
    {
        public IBProduct Product { get; private set; }

        public void BuildStepA()
        {
            Console.WriteLine("Alpha Step A");
        }

        public void BuildStepB()
        {
            Console.WriteLine("Alpha Step B");
        }

        public void BuildStepC()
        {
            Console.WriteLine("Alpha Step C");
        }

        public void Reset()
        {
            Product = new BProductAlpha();
        }
    }

    public class BuilderBeta : IBuilder
    {
        public IBProduct Product { get; private set; }

        public void BuildStepA()
        {
            Console.WriteLine("Beta Step A");
        }

        public void BuildStepB()
        {
            Console.WriteLine("Beta Step B");
        }

        public void BuildStepC()
        {
            Console.WriteLine("Beta Step C");
        }

        public void Reset()
        {
            Product = new BProductBeta();
        }
    }

    public interface IBProduct
    { }

    public class BProductAlpha : IBProduct
    { }

    public class BProductBeta : IBProduct
    { }

    public class Director
    {
        private IBuilder _builder;

        public Director(IBuilder builder)
            => _builder = builder;

        public IBProduct BuildProduct(bool isAlpha)
        {
            _builder.Reset();
            if (isAlpha)
            {
                _builder.BuildStepA();
            }
            else
            {
                _builder.BuildStepB();
                _builder.BuildStepC();
            }

            return _builder.Product;
        }
    }

    public class BuilderClient
    {
        public void UseBuilder()
        {
            var director = new Director(new BuilderBeta());
            var product = director.BuildProduct(true);
        }
    }
}