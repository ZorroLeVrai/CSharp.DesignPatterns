using Xunit;

namespace DesignPattern.Behavioural;

/// <summary>
/// Chain of Responsibility lets you pass requests along a chain of handlers.
/// Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.
/// </summary>
public interface IHandler
{
    void SetNext(IHandler handler);
    string Handle(Request request);
}

public class NullHandler : IHandler
{
    public string Handle(Request request) => string.Empty; // No operation, no next handler to call.

    public void SetNext(IHandler handler)
    {}
}

public class BasicHandler : IHandler
{
    private IHandler next = new NullHandler();

    public virtual string Handle(Request request)
    {
        return next.Handle(request);
    }

    public void SetNext(IHandler handler)
    {
        next = handler;
    }
}

public class OddHandler : BasicHandler
{
    public override string Handle(Request request)
    {
        if (CanHandle(request))
        {
            // Handle odd number by dividing it by 2 and adding 1
            return $"{request.Number} - Odd Handler";
        }
        else
        {
            return base.Handle(request);
        }
    }

    private bool CanHandle(Request request)
    {
        return 1 == request.Number % 2;
    }
}

public class EvenHandler : BasicHandler
{
    public override string Handle(Request request)
    {
        if (CanHandle(request))
        {
            // Handle even number by dividing it by 2
            return $"{request.Number} - Even Handler";
        }
        else
        {
            return base.Handle(request);
        }
    }

    private bool CanHandle(Request request)
    {
        return 0 == request.Number % 2;
    }
}


public record Request(int Number);

public class ChainOfResponsibilityClient : AbstractRunner
{
    public override void Run()
    {
        var handler = new OddHandler();
        handler.SetNext(new EvenHandler());

        var result1 = handler.Handle(new Request(7));
        Assert.Equal("7 - Odd Handler", result1);

        var result2 = handler.Handle(new Request(6));
        Assert.Equal("6 - Even Handler", result2);
    }
}
