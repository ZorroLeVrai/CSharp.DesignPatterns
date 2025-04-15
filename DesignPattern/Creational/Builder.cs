using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Creational;

/// <summary>
/// Builder lets you construct complex objects step by step.
/// The pattern allows you to produce different types and representations of an object using the same construction code.
/// </summary>
public interface IBuilder
{
    IBProduct Product { get; }

    void Init();
    void BuildStepA();
    void BuildStepB();
    void BuildStepC();
}

public class BuilderAlpha : IBuilder
{
    public IBProduct Product { get; private set; }

    public BuilderAlpha()
    {
        Product = new BProductAlpha();
    }

    public void BuildStepA()
    {
        Product.AddStep("Alpha Step A");
    }

    public void BuildStepB()
    {
        Product.AddStep("Alpha Step B");
    }

    public void BuildStepC()
    {
        Product.AddStep("Alpha Step C");
    }

    public void Init()
    {
        Product = new BProductAlpha();
    }
}

public class BuilderBeta : IBuilder
{
    public IBProduct Product { get; private set; }

    public void BuildStepA()
    {
        Product.AddStep("Beta Step A");
    }

    public void BuildStepB()
    {
        Product.AddStep("Beta Step B");
    }

    public void BuildStepC()
    {
        Product.AddStep("Beta Step C");
    }

    public void Init()
    {
        Product = new BProductBeta();
    }
}

public interface IBProduct
{
    IReadOnlyList<string> Steps { get; }

    void AddStep(string step);
}

public class BProductAlpha : IBProduct
{
    private readonly List<string> _steps = new();

    public IReadOnlyList<string> Steps => _steps;

    public void AddStep(string step)
    {
        _steps.Add(step);
    }
}

public class BProductBeta : IBProduct
{
    private readonly List<string> _steps = new();

    public IReadOnlyList<string> Steps => _steps;

    public void AddStep(string step)
    {
        _steps.Add(step);
    }
}

public class Director
{
    private readonly IBuilder _builder;

    public Director(IBuilder builder)
        => _builder = builder;

    public IBProduct BuildProduct()
    {
        _builder.Init();
        _builder.BuildStepA();
        _builder.BuildStepB();
        _builder.BuildStepC();

        return _builder.Product;
    }
}

public class BuilderClient : AbstractRunner
{
    public override void Run()
    {
        var director = new Director(new BuilderBeta());
        var product = director.BuildProduct();
        Assert.Equal(product.Steps.Count, 3);
        Assert.Equal(product.Steps[0], "Beta Step A");
        Assert.Equal(product.Steps[1], "Beta Step B");
        Assert.Equal(product.Steps[2], "Beta Step C");
    }
}