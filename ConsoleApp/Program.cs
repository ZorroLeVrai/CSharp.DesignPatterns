using DesignPattern.Behavioural;
using DesignPattern.Creational;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new BuilderClient();
            client.UseBuilder();
        }
    }
}
