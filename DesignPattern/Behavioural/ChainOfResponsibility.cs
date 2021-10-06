using System;

namespace DesignPattern.Behavioural
{
    //Chain of Responsibility lets you pass requests along a chain of handlers.
    //Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

    public interface IHandler
    {
        void SetNext(IHandler handler);
        void Handle(Request request);
    }

    public class NullHandler : IHandler
    {
        public void Handle(Request request)
        {}

        public void SetNext(IHandler handler)
        {}
    }

    public class BasicHandler : IHandler
    {
        private IHandler next = new NullHandler();

        public virtual void Handle(Request request)
        {
            next.Handle(request);
        }

        public void SetNext(IHandler handler)
        {
            next = handler;
        }
    }

    public class OddHandler : BasicHandler
    {
        public override void Handle(Request request)
        {
            if (CanHandle(request))
            {
                Console.WriteLine($"{request.Number / 2} + 1");
            }
            else
            {
                base.Handle(request);
            }
        }

        private bool CanHandle(Request request)
        {
            return 1 == request.Number % 2;
        }
    }

    public class EvenHandler : BasicHandler
    {
        public override void Handle(Request request)
        {
            if (CanHandle(request))
            {
                Console.WriteLine($"{request.Number / 2}");
            }
            else
            {
                base.Handle(request);
            }
        }

        private bool CanHandle(Request request)
        {
            return 0 == request.Number % 2;
        }
    }


    public record Request(int Number);

    public class ChainOfResponsibilityClient
    {
        public void UseChainResponsability()
        {
            var handler = new OddHandler();
            handler.SetNext(new EvenHandler());

            handler.Handle(new Request(7));
            handler.Handle(new Request(6));
        }
    }
}
