using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Structural;

/// <summary>
/// Composite lets you compose objects into tree structures and then work with these structures
/// as if they were individual objects.
/// </summary>
public interface IComponent
{
    IReadOnlyList<string> Execute();
}

public record LeafComponent(string Name) : IComponent
{
    public IReadOnlyList<string> Execute() => new[] { $"{Name} executed" };
}

public record CompositeComponent : IComponent
{
    private readonly List<IComponent> _children = new();

    public void Add(IComponent child)
    {
        _children.Add(child);
    }

    public IReadOnlyList<string> Execute()
    {
        var results = new List<string>();

        foreach(var child in _children)
        {
            results.AddRange(child.Execute());
        }
        
        return results;
    }
}


public class CompositeClient : AbstractRunner
{
    private readonly IComponent _component;

    public override void Run()
    {
        var composite = new CompositeComponent();
        composite.Add(new LeafComponent("Bob"));
        composite.Add(new LeafComponent("John"));
        composite.Add(new LeafComponent("Jane"));

        var results = composite.Execute();
        Assert.Equal(3, results.Count);
        Assert.Equal("Bob executed", results[0]);
        Assert.Equal("John executed", results[1]);
        Assert.Equal("Jane executed", results[2]);
    }

    public void Execute()
        => _component.Execute();
}
