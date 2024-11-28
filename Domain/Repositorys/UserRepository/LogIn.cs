using Data.Entities;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys.UserRepository
{
    public static class LogIn
    {
        public static User FindingUser(string email)
        {
            User pickedUser = null;
            foreach (var user in UsersAndProductsData.users.Values)
            {
                if (email == user.userEmail)
                {
                    pickedUser = user;
                }
                else if (email == "/SIGNUP")
                {
                    return null;
                }
            }
            if (pickedUser == null)
            {
                return null;
            }
            return pickedUser;
        }
    }
}
