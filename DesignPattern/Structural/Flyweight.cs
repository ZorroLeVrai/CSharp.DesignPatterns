using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Structural;

/// <summary>
/// Flyweight lets you fit more objects into the available amount of RAM by sharing common parts of state
/// between multiple objects instead of keeping all of the data in each object.
/// </summary>
/// <param name="Name"></param>
public record TreeType(string Name)
{
    private readonly char[] _sprite = new char[1024];

    public string Display() => $"{Name}: Sprite content";
}

public class TreeTypeCache
{
    private readonly Dictionary<string, TreeType> _treeDico = new();

    public TreeType GetTreeType(string name)
    {
        if (_treeDico.TryGetValue(name, out TreeType treeType))
            return treeType;

        treeType = new TreeType(name);
        _treeDico.Add(name, treeType);
        return treeType;
    }
}

public class Forest
{
    private readonly List<Tree> _trees = new();
    private readonly TreeTypeCache _treeTypeCache = new();

    public void AddTree(double x, double y, string typeName)
    {
        _trees.Add(new Tree(_treeTypeCache.GetTreeType(typeName), x, y, typeName));
    }

    public string[] Display()
    {
        var result = new string[_trees.Count];
        for (int i = 0; i < _trees.Count; i++)
        {
            result[i] = _trees[i].Display();
        }
        return result;
    }
}

public class Tree
{
    private readonly TreeType _treeType;

    public double X { get; }
    public double Y { get; }

    public string TypeName { get; }

    public Tree(TreeType treeType, double x, double y, string typeName)
    {
        _treeType = treeType;
        X = x;
        Y = y;
        TypeName = typeName;
    }

    public string Display() => $"{TypeName} at ({X}, {Y}) - {_treeType.Display()}";
}

public class FlyweightClient : AbstractRunner
{
    public override void Run()
    {
        var forest = new Forest();
        forest.AddTree(1, 1, "Sapin");
        forest.AddTree(1, 72, "Pin");
        forest.AddTree(101, 72, "Pin");
        var results = forest.Display();
        Assert.Equal(3, results.Length);
        Assert.Equal("Sapin at (1, 1) - Sapin: Sprite content", results[0]);
        Assert.Equal("Pin at (1, 72) - Pin: Sprite content", results[1]);
        Assert.Equal("Pin at (101, 72) - Pin: Sprite content", results[2]);
    }
}
