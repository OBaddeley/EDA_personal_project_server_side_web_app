using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopShopShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual List<ApplicationUser> Shoppers { get; set; }
    } 
}