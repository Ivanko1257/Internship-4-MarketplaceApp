using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Seller : User
    {
        public double profitFromProducts;
        public List<Guid> productsOfSeller;
        public Seller(string name, string surname, string email) : base(name, surname, email)
        {
            this.profitFromProducts = 0;
        }
    }
}
