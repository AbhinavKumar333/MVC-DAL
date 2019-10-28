using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAPI.Models
{
    public partial class Product
    {
        public int productId { get; set; }
        public string productname { get; set; }
        public string productType { get; set; }
        public Nullable<int> productPrice { get; set; }
        public string productDescription { get; set; }
    }
}