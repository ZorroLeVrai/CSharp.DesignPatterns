using DesignPattern.Others.NonNull;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new NonNullStructClient();
            client.UseNonNull();
        }
    }
}
