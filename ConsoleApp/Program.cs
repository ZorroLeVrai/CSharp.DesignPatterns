using DesignPattern.Behavioural;
using DesignPattern.Creational;
using DesignPattern.Others;
using DesignPattern.Structural;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new EnumClassClient();
            client.UseEmployee();
        }
    }
}
