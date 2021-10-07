using DesignPattern.Others;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new UnionClient();
            client.Exec();
        }
    }
}
