using System.ComponentModel.DataAnnotations;

namespace UrlShortener.ViewModels
{
    public class ShortenModel
    {
        [Required]
        public string Url { get; set; }
        
        public string ShortenedUrl { get; set; }

    }
}