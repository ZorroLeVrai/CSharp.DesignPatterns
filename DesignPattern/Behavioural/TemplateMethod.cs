using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Behavioural;

/// <summary>
/// Template Method defines the skeleton of an algorithm in the superclass but lets subclasses override specific steps
/// of the algorithm without changing its structure.
/// </summary>
public abstract class TemplateMethodBase
{
    public IReadOnlyList<string> TemplateMethod()
    {
        var actions = new List<string>();
        actions.Add(DoActionA());
        actions.Add(DoActionB());
        return actions;
    }

    protected abstract string DoActionA();
    protected abstract string DoActionB();
}

public class TemplateMethodAlpha : TemplateMethodBase
{
    protected override string DoActionA()
        => "Alpha do Action A";

    protected override string DoActionB()
        => "Alpha do Action B";
}

public class TemplateMethodBeta : TemplateMethodBase
{
    protected override string DoActionA()
        => "Beta do Action A";

    protected override string DoActionB()
        => "Beta do Action B";
}

public class TemplateMethodClient : AbstractRunner
{
    public override void Run()
    {
        var actions1 = new TemplateMethodAlpha().TemplateMethod();
        Assert.Equal(2, actions1.Count);
        Assert.Equal("Alpha do Action A", actions1[0]);
        Assert.Equal("Alpha do Action B", actions1[1]);
        
        var actions2 = new TemplateMethodBeta().TemplateMethod();
        Assert.Equal(2, actions2.Count);
        Assert.Equal("Beta do Action A", actions2[0]);
        Assert.Equal("Beta do Action B", actions2[1]);
    }
}
