using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Data
{
    public class Url
    {
        [Key]
        public string Id { get; set; }
        public string Hash { get; set; }
        public string OriginalUrl { get; set; }
    }
}