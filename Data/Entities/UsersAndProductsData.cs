using Data.Entities.Models;
using Data.Entities.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public static class UsersAndProductsData
    {
        public static Dictionary<Guid, User> users{ get; set; } = Seeds.Seeds.Users;
        public static Dictionary<Guid, Product> products { get; set; } = Seeds.Seeds.Products;
    }
}
