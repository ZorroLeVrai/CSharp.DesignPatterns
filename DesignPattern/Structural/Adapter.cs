namespace DesignPattern.Structural
{
    //Adapter allows objects with incompatible interfaces to collaborate

    /// <summary>
    /// Interface to implement
    /// </summary>
    public interface IAlpha
    {
        void Draw();
    }

    /// <summary>
    /// External library to adapt
    /// </summary>
    public class AAlpha
    {
        public void Dessiner()
        {
            System.Console.WriteLine("Dessiner");
        }
    }

    /// <summary>
    /// Adapter
    /// </summary>
    public class AdapterAlpha : IAlpha
    {
        private readonly AAlpha _alpha;

        public AdapterAlpha(AAlpha alpha)
            => _alpha = alpha;

        public void Draw()
        {
            _alpha.Dessiner();
        }
    }

    public class AdapterClient
    {
        public void UseAdapter()
        {
            IAlpha adapter = new AdapterAlpha(new AAlpha());
            adapter.Draw();
        }
    }
}