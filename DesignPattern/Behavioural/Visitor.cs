namespace DesignPattern.Behavioural
{
    //Visitor lets you separate algorithms from the objects on which they operate.
    //The Visitor pattern suggests that you place the new behavior into a separate class called visitor,
    //instead of trying to integrate it into existing classes.

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
            System.Console.WriteLine(product.Name);
        }

        public void VisitProductB(ProductBeta product)
        {
            product.Title = $"{product.Title} visited by VisitorOne";
            System.Console.WriteLine(product.Title);
        }
    }

    public class VisitorTwo : IVisitor
    {
        public void VisitProductA(ProductAlpha product)
        {
            product.Name = $"{product.Name} visited by VisitorTwo";
            System.Console.WriteLine(product.Name);
        }

        public void VisitProductB(ProductBeta product)
        {
            product.Title = $"{product.Title} visited by VisitorTwo";
            System.Console.WriteLine(product.Title);
        }
    }


    public class VisitorClient
    {
        public void UseVisitor()
        {
            var productA = new ProductAlpha("Adam");
            var productB = new ProductBeta("Lise");

            var visitor1 = new VisitorOne();
            var visitor2 = new VisitorTwo();

            productA.Accept(visitor1);
            productB.Accept(visitor2);
        }
    }
}