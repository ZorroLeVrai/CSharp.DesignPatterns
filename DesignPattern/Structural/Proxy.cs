using System;
using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Structural;

/// <summary>
/// Proxy lets you provide a substitute or placeholder for another object.
/// A proxy controls access to the original object, allowing you to perform something
/// either before or after the request gets through to the original object.
/// </summary>
public interface IService
{
    string Execute();
}

public class RealService : IService
{
    public string Execute() => "Execute service";
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

    public string Execute()
    {
        var strings = new List<string>() { "Before execution" };

        if (_isExecute)
            strings.Add(_service.Execute());

        strings.Add("After execution");
        return string.Join(" | ", strings);
    }
}

public class ProxyClient : AbstractRunner
{
    public override void Run()
    {
        var proxy = new ProxyService(new RealService(), true);
        var resultExecute = proxy.Execute();
        Assert.Equal("Before execution | Execute service | After execution", resultExecute);
    }
}
