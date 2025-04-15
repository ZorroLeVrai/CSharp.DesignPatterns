using Xunit;

namespace DesignPattern.Behavioural;

/// <summary>
/// Strategy lets you define a family of algorithms, put each of them into a separate class,
/// and make their objects interchangeable.
/// </summary>
public interface IStrategy
{
    string Exectute();
}

public class ConcreteStrategyAlpha : IStrategy
{
    public string Exectute()
        => "Execute Strategy A";
}

public class ConcreteStrategyBeta : IStrategy
{
    public string Exectute()
        => "Execute Strategy B";
}

public class StrategyContext
{
    public IStrategy Strategy { get; set; }

    public StrategyContext(IStrategy strategy)
    {
        Strategy = strategy;
    }

    public string DoSomething()
        => Strategy.Exectute();
}

public class StrategyClient : AbstractRunner
{
    public override void Run()
    {
        var context = new StrategyContext(new ConcreteStrategyAlpha());
        var actionLog = context.DoSomething();
        Assert.Equal("Execute Strategy A", actionLog);
        context = new StrategyContext(new ConcreteStrategyBeta());
        actionLog = context.DoSomething();
        Assert.Equal("Execute Strategy B", actionLog);
    }
}
