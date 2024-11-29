using Data.Entities;
using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositorys
{
    public static class HelpFunctions
    { 
        public static bool IsOperationValid(List<int> avalabelOptions,int pickedOperation)
        {
            foreach(var operation in  avalabelOptions)
            {
                if (operation == pickedOperation)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsOperationConfirmed()
        {
            string confirmationCheck = null;
            while(confirmationCheck == null)
            {
                confirmationCheck = Console.ReadLine();
                if (confirmationCheck.ToLower() == "da") return true;
                else if (confirmationCheck.ToLower() == "ne") break;
                else Console.Write("Odgovor nije validan. Pokušajte ponovo: ");
            }
            return false;
        }
    }
}
