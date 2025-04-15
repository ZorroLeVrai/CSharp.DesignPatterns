using System;

namespace DesignPattern;

public abstract class AbstractRunner
{
    public void Exec()
    {
        Console.WriteLine($"{this.GetType().Name} - Run");
        Run();
    }

    public abstract void Run();
}
