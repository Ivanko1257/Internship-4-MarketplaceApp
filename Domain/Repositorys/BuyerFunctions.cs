using Data.Entities;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys
{
    public static class BuyerFunctions
    {
        public static Product FindProduct(string ID)
        {
            foreach (var product in UsersAndProductsData.products.Values)
            {
                if (product.id.ToString() == ID) return product;
            }
            return null;
        }
        public static Product FindProductInHistory(string ID, Buyer buyer)
        {
            foreach(var transaction in buyer.transactionHistory)
            {
                if(transaction.idOfProduct.ToString() == ID) return FindProduct(ID);
            }
            return null;
        }
        public static bool IsAlreadyInFavourites(Buyer buyer, Product productToCheck)
        {
            foreach(var product in buyer.productsInFavourites)
            {
                if(productToCheck == product) return true;
            }
            return false;
        }
    }
}
