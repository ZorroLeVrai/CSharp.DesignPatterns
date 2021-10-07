using DesignPattern.Others;
using DesignPattern.Others.Encapsulation;
using DesignPattern.Others.NonNull;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new CartClient();
            client.UseCart();
        }
    }
}
