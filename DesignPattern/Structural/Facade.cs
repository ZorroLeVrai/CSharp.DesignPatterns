using System;
using Xunit;

namespace DesignPattern.Structural;

/// <summary>
/// Facade lets you provide a simple interface to a complex subsystem.
/// </summary>
public class DownloadVideo
{
    public VideoFile GetFile(string url)
        => new();
}

public enum VideoType
{
    Avi,
    Mpeg
}

public class VideoFile
{
    public VideoType GetVideoType()
        => VideoType.Mpeg;
}

public class Mpeg4CompressionCodec
{
    public string Display() => "Display Mpeg4";
}

public class AviCompressionCodec
{
    public string Display() => "Display Avi";
}

/// <summary>
/// Make the library easier to use
/// </summary>
public class Facade
{
    private readonly DownloadVideo _videoDownloader;
    private VideoFile _video;

    public Facade()
    {
        _videoDownloader = new DownloadVideo();
    }

    public void GetVideo(string url)
    {
        _video = _videoDownloader.GetFile(url);
    }

    public string Display()
    {
        return _video.GetVideoType() switch
        {
            VideoType.Avi => new AviCompressionCodec().Display(),
            VideoType.Mpeg => new Mpeg4CompressionCodec().Display(),
            _ => throw new Exception("Unknown type")
        };
    }
}

public class FacadeClient : AbstractRunner
{
    public override void Run()
    {
        var facade = new Facade();
        facade.GetVideo("http://video.com");
        var displayResult = facade.Display();
        Assert.Equal("Display Mpeg4", displayResult);
    }
}
