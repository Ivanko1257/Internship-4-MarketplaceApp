using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public static class CheckingForValid
    {
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
