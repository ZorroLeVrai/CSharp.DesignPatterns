using DesignPattern.Behavioural;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ChainOfResponsibilityClient();
            client.UseChainResponsability();
        }
    }
}
