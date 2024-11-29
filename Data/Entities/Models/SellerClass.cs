using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Seller : User
    {
        public double profitFromProducts;
        public List<Product> productsOfSeller;
        public List<Transaction> transactionsOfSellersProducts;
        public Seller(string name, string surname, string email, List<Product> products) : base(name, surname, email)
        {
            profitFromProducts = 0;
            productsOfSeller = products;
            transactionsOfSellersProducts = new List<Transaction>() { };
        }
    }
}
