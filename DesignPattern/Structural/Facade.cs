using System;

namespace DesignPattern.Structural
{
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
        public void Display()
            => Console.WriteLine("Display Mpeg4");
    }

    public class AviCompressionCodec
    {
        public void Display()
            => Console.WriteLine("Display Avi");
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

        public void Display()
        {
            switch (_video.GetVideoType())
            {
                case VideoType.Avi:
                    new AviCompressionCodec().Display();
                    return;
                case VideoType.Mpeg:
                    new Mpeg4CompressionCodec().Display();
                    return;
                default:
                    throw new Exception("Unknown type");
            }
        }
    }

    public class FacadeClient
    {
        public void UseFacade()
        {
            var facade = new Facade();
            facade.GetVideo("http://video.com");
            facade.Display();
        }
    }
}
