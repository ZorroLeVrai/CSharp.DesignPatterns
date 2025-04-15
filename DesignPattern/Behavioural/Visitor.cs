using Xunit;

namespace DesignPattern.Behavioural;

/// <summary>
/// Visitor lets you separate algorithms from the objects on which they operate.
/// The Visitor pattern suggests that you place the new behavior into a separate class called visitor,
/// instead of trying to integrate it into existing classes.
/// </summary>

public interface IProduct
{
    void Accept(IVisitor visitor);
}

public class ProductAlpha : IProduct
{
    public string Name { get; set; }

    public ProductAlpha(string name)
        => Name = name;

    public void Accept(IVisitor visitor)
    {
        visitor.VisitProductA(this);
    }
}

public class ProductBeta : IProduct
{
    public string Title { get; set; }

    public ProductBeta(string title)
        => Title = title;

    public void Accept(IVisitor visitor)
    {
        visitor.VisitProductB(this);
    }
}

public interface IVisitor
{
    void VisitProductA(ProductAlpha product);
    void VisitProductB(ProductBeta product);
}

public class VisitorOne : IVisitor
{
    public void VisitProductA(ProductAlpha product)
    {
        product.Name = $"{product.Name} visited by VisitorOne";
    }

    public void VisitProductB(ProductBeta product)
    {
        product.Title = $"{product.Title} visited by VisitorOne";
    }
}

public class VisitorTwo : IVisitor
{
    public void VisitProductA(ProductAlpha product)
    {
        product.Name = $"{product.Name} visited by VisitorTwo";
    }

    public void VisitProductB(ProductBeta product)
    {
        product.Title = $"{product.Title} visited by VisitorTwo";
    }
}


public class VisitorClient : AbstractRunner
{
    public override void Run()
    {
        var productJohn = new ProductAlpha("John");
        var productJane = new ProductBeta("Jane");

        var visitor1 = new VisitorOne();
        var visitor2 = new VisitorTwo();

        productJohn.Accept(visitor1);
        Assert.Equal("John visited by VisitorOne", productJohn.Name);

        productJane.Accept(visitor2);
        Assert.Equal("Jane visited by VisitorTwo", productJane.Title);
    }
}
