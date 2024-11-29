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
        public static string? CheckifEmailIsValid()
        {
            var input = Console.ReadLine();
            string[] inputSplitByMonkey = input.Split('@');
            if (inputSplitByMonkey.Length != 2)
            {
                return null;
            }
            if (inputSplitByMonkey[0].Length < 1)
            {
                return null;
            }
            string[] inputSplitByTheDot = input.Split(".");
            if (inputSplitByTheDot.Length != 2)
            {
                return null;
            }
            if (inputSplitByTheDot[0].Length < 3)
            {
                return null;
            }
            if (inputSplitByTheDot[1].Length < 2)
            {
                return null;
            }
            return input;
        }
    }
}
