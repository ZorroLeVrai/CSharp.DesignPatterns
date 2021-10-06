namespace DesignPattern.Creational
{
    //Factory Method provides an interface for creating objects in a superclass
    //but allows subclasses to alter the type of objects that will be created.

    public interface IFactoryMethod
    {
        IFactoryMethodModel CreateModel();
    }

    /// <summary>
    /// The factory method is just a method, it can be overridden in a subclass
    /// </summary>
    ///
    public class FactoryMethodAlpha : IFactoryMethod
    {
        public virtual IFactoryMethodModel CreateModel()
            => new AlphaFMModel();
    }

    public class FactoryMethodSuperAlpha : FactoryMethodAlpha
    {
        //because it is a factory method, I can override the `create` function
        public override IFactoryMethodModel CreateModel()
            => new SuperAlphaFMModel();
    }

    public class FactoryMethodBeta : IFactoryMethod
    {
        public IFactoryMethodModel CreateModel()
            => new BetaFMModel();
    }


    public interface IFactoryMethodModel
    {
        string GetName();
    }

    public class AlphaFMModel : IFactoryMethodModel
    {
        public string GetName()
            => "Alpha";
    }

    public class SuperAlphaFMModel : IFactoryMethodModel
    {
        public string GetName()
            => "SuperAlpha";
    }

    public class BetaFMModel : IFactoryMethodModel
    {
        public string GetName()
            => "Beta";
    }

    public class FactoryMethodClient
    {
        public void UseFactoryMethod()
        {
            var factory = new FactoryMethodSuperAlpha();
            var model = factory.CreateModel();
            model.GetName();
        }
    }
}
