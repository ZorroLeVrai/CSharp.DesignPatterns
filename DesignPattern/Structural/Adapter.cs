using Xunit;

namespace DesignPattern.Structural;

/// <summary>
/// Adapter allows objects with incompatible interfaces to collaborate
/// </summary>
public interface IAlpha
{
    string Draw();
}

/// <summary>
/// External library to adapt
/// </summary>
public class AAlpha
{
    public string Dessiner() => "dessiner";
}

/// <summary>
/// Adapter
/// </summary>
public class AdapterAlpha : IAlpha
{
    private readonly AAlpha _alpha;

    public AdapterAlpha(AAlpha alpha)
        => _alpha = alpha;

    public string Draw() => _alpha.Dessiner();
}

public class AdapterClient : AbstractRunner
{
    public override void Run()
    {
        IAlpha adapter = new AdapterAlpha(new AAlpha());
        var result = adapter.Draw();
        Assert.Equal("dessiner", result);
    }
}
