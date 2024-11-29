using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class Transaction
    {
        public Guid idOfProduct { get; }
        public Buyer buyerOfProduct { get; }
        public Seller sellerOfProduct { get; }
        public DateTime timeOfTransaction { get; }
        public Transaction(Guid id, Buyer buyer, Seller seller)
        {
            idOfProduct = id;
            buyerOfProduct = buyer;
            sellerOfProduct = seller;
            timeOfTransaction = DateTime.Now;
        }

    }
}
