using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Structural;

//
/// <summary>
/// Decorator lets you attach new behaviors to objects by placing these objects
/// inside special wrapper objects that contain the behaviors
/// </summary>
public interface IDecoProduct
{
    IReadOnlyList<string> DisplayInfo();
}

public sealed class DecoProduct : IDecoProduct
{
    public IReadOnlyList<string> DisplayInfo() => new List<string>
    {
        "Product information"
    };
}

public record StandardDecorator(IDecoProduct Product) : IDecoProduct
{
    public virtual IReadOnlyList<string> DisplayInfo() => Product.DisplayInfo();
}

public record PreInfoDecorator(IDecoProduct Product)
    : StandardDecorator(Product)
{
    public override IReadOnlyList<string> DisplayInfo()
    {
        var result = new List<string>() { "Pre-Information" };
        result.AddRange(base.DisplayInfo());
        return result;
    }
}

public record PostInfoDecorator(IDecoProduct Product)
    : StandardDecorator(Product)
{
    public override IReadOnlyList<string> DisplayInfo()
    {
        var result = new List<string>(base.DisplayInfo());
        result.Add("Post-Information");
        return result;
    }
}

public class DecoratorClient : AbstractRunner
{
    public override void Run()
    {
        var decorator = new PreInfoDecorator(new PostInfoDecorator(new DecoProduct()));
        var results = decorator.DisplayInfo();
        Assert.Equal(3, results.Count);
        Assert.Equal("Pre-Information", results[0]);
        Assert.Equal("Product information", results[1]);
        Assert.Equal("Post-Information", results[2]);
    }
}
