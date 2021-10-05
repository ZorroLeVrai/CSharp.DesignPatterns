using DesignPattern.Behavioural;
using System;

namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ClientIterator();
            client.Display();
        }
    }
}
