using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Models
{
    public class User
    {
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userEmail { get; set; }
        public Guid id { get; }
        public User(string name, string surname, string email)
        {
            userName = name;
            userSurname = surname;
            userEmail = email;
            id = Guid.NewGuid();
        }
    }
}
