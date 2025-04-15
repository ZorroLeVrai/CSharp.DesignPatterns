using Xunit;

namespace DesignPattern.Creational;

/// <summary>
/// Prototype lets you copy existing objects without making your code dependent on their classes.
/// </summary>
public interface IPrototype
{
    IPrototype Clone();
}

public class PrototypeAlpha : IPrototype
{
    public string FieldA { get; }

    public PrototypeAlpha(ProtoProduct product)
    {
        FieldA = product.FieldA;
    }

    protected PrototypeAlpha(PrototypeAlpha other)
    {
        FieldA = other.FieldA;
    }

    public virtual IPrototype Clone()
    {
        return new PrototypeAlpha(this);
    }
}

public class SubPrototypeAlpha : PrototypeAlpha
{
    public string FieldB { get; }

    public SubPrototypeAlpha(ProtoProduct product)
        :base(product)
    {
        FieldB = product.FieldB;
    }

    private SubPrototypeAlpha(SubPrototypeAlpha other)
        :base(other)
    {
        FieldB = other.FieldB;
    }

    public override IPrototype Clone()
    {
        return new SubPrototypeAlpha(this);
    }
}

public record ProtoProduct(string FieldA, string FieldB, string FieldC, string FieldD);

public class PrototypeClient: AbstractRunner
{
    public override void Run()
    {
        var product = new ProtoProduct("A", "B", "C", "D");
        var prototype = new SubPrototypeAlpha(product);
        var prototype2 = prototype.Clone();
        Assert.True(prototype2 is SubPrototypeAlpha);
        Assert.Equal(((SubPrototypeAlpha)prototype2).FieldA, "A");
        Assert.Equal(((SubPrototypeAlpha)prototype2).FieldB, "B");
    }
}
