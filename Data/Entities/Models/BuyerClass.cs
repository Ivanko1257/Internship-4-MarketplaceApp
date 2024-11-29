using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Buyer : User
    {
        public double userBalance { get; set; }
        public List<Product> productsInFavourites { get; set; }
        public List<Transaction> transactionHistory { get; set; }
        public Buyer(string name, string surname, string email, double balance) : base(name, surname, email)
        {
            userBalance = balance;
            productsInFavourites = new List<Product>();
            transactionHistory = new List<Transaction>();
        }
    }
}
