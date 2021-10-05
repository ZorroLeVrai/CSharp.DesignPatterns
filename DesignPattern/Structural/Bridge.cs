using System;

namespace DesignPattern.Structural
{
    //Bridge lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction and implementation
    //which can be developed independently of each other.

    public abstract class Shape
    {
        private readonly Color _color;

        public Shape(Color color)
            => _color = color;

        public abstract string Name { get; }

        public void Display()
            => Console.WriteLine($"Shape is {Name} and Color is {_color.Name}");
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

    public class Bridge
    {
        private readonly Shape[] _shapes = {
            new Circle(new Blue()),
            new Square(new Red())
        };

        public void DisplayShapes()
        {
            foreach (var shape in _shapes)
                shape.Display();
        }
    }
}
