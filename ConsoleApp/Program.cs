using DesignPattern.Others.Encapsulation;
using DesignPattern.Others.NonNull;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new InterfaceRestrictorClient();
            client.Exec();
        }
    }
}
