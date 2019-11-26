using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using UrlShortener.Data;

namespace UrlShortener.Services
{
    public interface IShorteningService
    {
        public string ShortenAndStore(string url);
    }

    public class ShorteningService : IShorteningService
    {
        private readonly DataContext _db;
        private readonly IUrlHelper _url;
        
        public ShorteningService(DataContext ctx, IUrlHelper url) {
            _db = ctx;
            _url = url;
        } 
        private string Hash(string url)
        {
            using(var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(url));
                return Encoding.ASCII.GetString(hashBytes);
            }
        }

        public string ShortenAndStore(string url)
        {
            var urlModel = new Url(){
                OriginalUrl = url,
                Hash = this.Hash(url)
            };
            _db.Urls.Add(urlModel);
            _db.SaveChanges();

            // return _url.GetPathByName(HttpContext, )
            return _url.Action("RedirectUrl","UrlController", new {
                Hash = urlModel.Hash
            });
        }
    }
}