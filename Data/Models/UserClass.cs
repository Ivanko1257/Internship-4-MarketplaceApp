﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class User
    {
        public string userName {  get; set; }
        public string userSurname {  get; set; }
        public string userEmail {  get; set; }
        public User(string name, string surname, string email)
        {
            userName = name;
            userSurname = surname;
            userEmail = email;
        }
    }
}
