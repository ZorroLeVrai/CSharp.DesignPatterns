﻿using Xunit;

namespace DesignPattern.Creational;

/// <summary>
/// The Factory Method pattern provides an interface for creating objects in a superclass
/// but allows subclasses to alter the type of objects that will be created.
/// </summary>
public interface IFactoryMethod
{
    IFactoryMethodModel CreateModel();
}

/// <summary>
/// The factory method is just a method, it can be overridden in a subclass
/// </summary>
///
public class FactoryMethodAlpha : IFactoryMethod
{
    public virtual IFactoryMethodModel CreateModel()
        => new AlphaFMModel();
}

public class FactoryMethodSuperAlpha : FactoryMethodAlpha
{
    //because it is a factory method, I can override the `create` function
    public override IFactoryMethodModel CreateModel()
        => new SuperAlphaFMModel();
}

public class FactoryMethodBeta : IFactoryMethod
{
    public IFactoryMethodModel CreateModel()
        => new BetaFMModel();
}


public interface IFactoryMethodModel
{
    string GetName();
}

public class AlphaFMModel : IFactoryMethodModel
{
    public string GetName()
        => "Alpha";
}

public class SuperAlphaFMModel : IFactoryMethodModel
{
    public string GetName()
        => "SuperAlpha";
}

public class BetaFMModel : IFactoryMethodModel
{
    public string GetName()
        => "Beta";
}

public class FactoryMethodClient : AbstractRunner
{
    public override void Run()
    {
        var factory = new FactoryMethodSuperAlpha();
        var model = factory.CreateModel();
        var name = model.GetName();
        Assert.Equal(name, "SuperAlpha");
    }
}
