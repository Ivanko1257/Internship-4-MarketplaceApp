using Data.Entities;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys
{
    public static class SellerFunctions
    {
        public static bool IsCategoryValid(string productCategory)
        {
            foreach (var category in UsersAndProductsData.productCategories)
            {
                if (productCategory.ToLower() == category.ToLower()) return true;
            }
            return false;
        }
        public static Product AddProduct(string name, string description, string category, double balance, Seller seller)
        {
            Product newProduct = new Product(name, description, category, balance, seller);
            UsersAndProductsData.products.Add(newProduct.id, newProduct);
            return newProduct;
        }
    }
}
