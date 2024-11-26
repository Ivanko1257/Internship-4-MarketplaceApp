﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Transaction
    {
        public Guid idOfProduct { get; }
        public Buyer buyerOfProduct { get;}
        public Seller sellerOfProduct { get;}
        public DateTime timeOfTransaction { get;}
        public Transaction(Guid id, Buyer buyer, Seller seller, DateTime time)
        {
            idOfProduct = id;
            buyerOfProduct = buyer;
            sellerOfProduct = seller;
            timeOfTransaction = time;
        }

    }
}
