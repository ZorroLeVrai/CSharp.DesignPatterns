using System;

namespace DesignPattern.Structural
{
    //Proxy lets you provide a substitute or placeholder for another object.
    //A proxy controls access to the original object, allowing you to perform something
    //either before or after the request gets through to the original object.

    public interface IService
    {
        void Execute();
    }

    public class RealService : IService
    {
        public void Execute()
        {
            Console.WriteLine("Execute service");
        }
    }

    public class ProxyService : IService
    {
        private readonly IService _service;
        private readonly bool _isExecute;

        public ProxyService(IService service, bool isExecute)
        {
            _service = service;
            _isExecute = isExecute;
        }

        public void Execute()
        {
            Console.WriteLine("Before execution");

            if (_isExecute)
                _service.Execute();

            Console.WriteLine("After execution");
        }
    }

    public class ProxyClient
    {
        public void UseProxy()
        {
            var proxy = new ProxyService(new RealService(), true);
            proxy.Execute();
        }
    }
}
