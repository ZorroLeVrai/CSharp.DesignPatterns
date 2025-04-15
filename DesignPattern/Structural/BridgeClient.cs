using Xunit;

namespace DesignPattern.Structural;

/// <summary>
/// Bridge lets you split a large class or a set of closely related classes into
/// two separate hierarchies—abstraction and implementation which can be developed independently of each other.
/// </summary>
public abstract class Shape
{
    private readonly Color _color;

    public Shape(Color color)
        => _color = color;

    public abstract string Name { get; }

    public string GetDescription()
        => $"Shape is {Name} and Color is {_color.Name}";
}

public class Square : Shape
{
    public Square(Color color)
        :base(color)
    { }

    public override string Name => "Square";
}

public class Circle : Shape
{
    public Circle(Color color)
        : base(color)
    { }

    public override string Name => "Circle";
}

public abstract class Color
{
    public abstract string Name { get; }
}

public class Red : Color
{
    public override string Name => "Red";
}

public class Blue : Color
{
    public override string Name => "Blue";
}

public class BridgeClient : AbstractRunner
{
    public override void Run()
    {
        Shape[] _shapes = {
            new Circle(new Blue()),
            new Square(new Red())
        };

        string[] descriptions = new string[_shapes.Length];
        for (int i = 0; i < _shapes.Length; i++)
        {
            descriptions[i] = _shapes[i].GetDescription();
        }

        Assert.Equal("Shape is Circle and Color is Blue", descriptions[0]);
        Assert.Equal("Shape is Square and Color is Red", descriptions[1]);
    }
}
