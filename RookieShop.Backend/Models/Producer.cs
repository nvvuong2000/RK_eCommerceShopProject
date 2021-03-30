
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  RookieShop.Backend.Models
{
   public  class Producer
    {
        public int producerID { get; set; }
        public string producerName { get; set; }
        public string info { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string logo { get; set; }
        public IList<ProducerProduct> ProducerProducts { get; set; }
    }
}
