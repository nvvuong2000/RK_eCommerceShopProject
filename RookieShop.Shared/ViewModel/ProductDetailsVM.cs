using System;
using System.Collections.Generic;

namespace RookieShop.Shared.ViewModel
{
    public class ProductDetailsVM
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsNew { get; set; }
        public bool Status { get; set; }
        public double Rating { get; set; }
        public List<int> NumberRating { get; set; }
        public List<string> UserId { get; set; }
        public List<string> Alt { get; set; }
        public List<DateTime> DateRated { get; set; }
        public List<string> PathName { get; set; }

    }
}
