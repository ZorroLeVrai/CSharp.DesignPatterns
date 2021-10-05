namespace DesignPattern.Structural
{
    //Decorator lets you attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.

    public interface IDecoProduct
    {
        void DisplayInfo();
    }

    public class DecoProduct : IDecoProduct
    {
        public void DisplayInfo()
        {
            System.Console.WriteLine("Product information");
        }
    }

    public record StandardDecorator(IDecoProduct Product) : IDecoProduct
    {
        public virtual void DisplayInfo()
        {
            Product.DisplayInfo();
        }
    }

    public record PreInfoDecorator(IDecoProduct Product)
        : StandardDecorator(Product)
    {
        public override void DisplayInfo()
        {
            System.Console.WriteLine("Pre-Information");
            base.DisplayInfo();
        }
    }

    public record PostInfoDecorator(IDecoProduct Product)
        : StandardDecorator(Product)
    {
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            System.Console.WriteLine("Post-Information");
        }
    }
}
