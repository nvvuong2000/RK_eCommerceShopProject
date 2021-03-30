using System.ComponentModel.DataAnnotations;

namespace RookieShop.Shared
{
    public class categoryCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
