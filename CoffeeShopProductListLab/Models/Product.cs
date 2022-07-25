using System;
using System.Collections.Generic;

namespace CoffeeShopProductListLab.Models
{
    public partial class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }
    }
}
