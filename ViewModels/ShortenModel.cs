using System.ComponentModel.DataAnnotations;

namespace UrlShortener.ViewModels
{
    public class ShortenModel
    {
        [Required]
        [RegularExpression(@"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$")]
        public string Url { get; set; }
        
        public string ShortenedUrl { get; set; }

    }
}