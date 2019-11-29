namespace UrlShortener.Data.Repositories
{
    public interface IUrlRepository
    {
        string getUrl(string hash);
        void addUrl(string url, string hash);
    }
}