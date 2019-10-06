namespace UrlShortener.Services
{
    public interface IShorteningService
    {
        public string Shorten(string url);
    }

    public class ShorteningService : IShorteningService
    {
        public string Shorten(string url)
        {
            return url;
        }
    }
}