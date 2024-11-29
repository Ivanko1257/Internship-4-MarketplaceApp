using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys
{
    public static class BuyerFunctions
    {
        public static double CouponDiscount()
        {
            string couponToSearch = null;
            bool couponFound = false;
            while (!couponFound)
            {
                couponToSearch = Console.ReadLine();
                if (couponToSearch.ToLower() == "skip") return 1;
                else
                {
                    foreach(var coupon in Seeds.Cupons)
                    {
                        if (couponToSearch == coupon)
                        {
                            couponFound = true;
                        }
                    }
                }
                if(!couponFound) Console.Write("Unešeni kupon nije validan. Pokušajte ponovo: ");
            }
            Seeds.Cupons.Remove(couponToSearch);
            return 0.2;
        }
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
