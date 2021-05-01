
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IList<ProviderProduct> ProviderProducts { get; set; }
    }
}
