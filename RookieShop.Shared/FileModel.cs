using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace RookieShop.Shared
{
    public partial class  FileModel:ProductVM
    {
        public string FileName { get; set; }
       // public IFormFile FormFile { get; set; }
        public List<IFormFile> FormFiles { get; set; }
    }
}
