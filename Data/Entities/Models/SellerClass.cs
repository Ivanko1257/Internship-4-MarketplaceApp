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
        public List<Guid> productsOfSeller;
        public Seller(string name, string surname, string email, List<Guid> products) : base(name, surname, email)
        {
            profitFromProducts = 0;
            productsOfSeller = products;
        }
    }
}
