using System;
using System.Collections.Generic;
using System.Text;

namespace RookieShop.Shared.ViewModel
{
    public class UserListInfo
    {
        public string UserId { get; set; }

        public string FullName { get; set; }

        public string UserPhone { get; set; }

        public string UserEmail { get; set; }

        public string Avatar { get; set; }

        public int CountOrder { get; set; }

        public decimal TotalOrder { get; set; }


    }
}
