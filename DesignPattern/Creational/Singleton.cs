namespace DesignPattern.Creational
{
    //Singleton lets you ensure that a class has only one instance
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private Singleton()
        { }

        public static Singleton Instance
        {
            get => _instance;
        }
    }
}
