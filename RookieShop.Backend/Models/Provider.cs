
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
    public class Provider
    {
        public int providerID { get; set; }
        public string providerName { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public IList<ProviderProduct> ProviderProducts { get; set; }
    }
}
