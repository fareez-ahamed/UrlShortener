using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UrlShortener.Data;
using UrlShortener.Data.Repositories;

namespace UrlShortener.Services
{
    public interface IShorteningService
    {
        public string ShortenAndStore(string url);
    }

    public class ShorteningService : IShorteningService
    {
        private readonly IUrlRepository _urlRepo;
        private readonly IUrlHelper _url;
        private readonly IConfiguration _config;

        public ShorteningService(IUrlRepository urlRepo, IUrlHelper url, IConfiguration config)
        {
            this._urlRepo = urlRepo;
            this._url = url;
            this._config = config;
        }
        private string Hash(string url)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(url));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public string ShortenAndStore(string url)
        {
            var hash = Hash(url);
            this._urlRepo.addUrl(url, hash);

            // return _url.GetPathByName(HttpContext, )
            return _config.GetValue<string>("Application:BaseUrl") + _url.Action("RedirectUrl", "UrlController", new
            {
                Hash = hash
            });
        }
    }
}