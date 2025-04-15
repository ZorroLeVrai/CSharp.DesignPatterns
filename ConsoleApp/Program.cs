using System;
using System.Linq;
using System.Reflection;

namespace DesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Assembly.Load("DesignPattern").GetTypes()
            .Where(t => t.IsClass && t.BaseType == typeof(AbstractRunner))
            .ToList()
            .ForEach(t =>
            {
                var instance = Activator.CreateInstance(t) as AbstractRunner;
                instance?.Exec();
            });
    }
}
