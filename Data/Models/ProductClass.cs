﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Product
    {
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productCategory {  get; set; }
        public double productPrice {  get; set; }
        public Seller sellerOfProduct { get; set; }
        public Product(string name, string description, string category, double price, Seller seller)
        {
            productName = name;
            productDescription = description;
            productCategory = category;
            productPrice = price;
            sellerOfProduct = seller;
        }
    }
}
