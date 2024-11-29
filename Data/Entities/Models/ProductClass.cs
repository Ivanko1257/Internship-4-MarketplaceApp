using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Product
    {
        public Guid id { get; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public double productPrice { get; set; }
        public ProductStatus productStatus { get; set; }
        public User sellerOfProduct { get; }
        public Product(string name, string description, string category, double price, User seller)
        {
            productName = name;
            productDescription = description;
            productCategory = category;
            productPrice = price;
            sellerOfProduct = seller;
            id = Guid.NewGuid();
            productStatus = ProductStatus.NaProdaji;
        }
    }
}
