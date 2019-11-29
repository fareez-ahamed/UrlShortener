using System.Linq;

namespace UrlShortener.Data.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly DataContext _db;
        public UrlRepository(DataContext ctx) => _db = ctx;

        public async void addUrl(string url, string hash)
        {
            var urlModel = new Url()
            {
                OriginalUrl = url,
                Hash = hash
            };
            _db.Urls.Add(urlModel);
            await _db.SaveChangesAsync();
        }

        public string getUrl(string hash)
        {
            var url = _db.Urls.Where(url => url.Hash == hash).First();
            return url.OriginalUrl;
        }
    }
}