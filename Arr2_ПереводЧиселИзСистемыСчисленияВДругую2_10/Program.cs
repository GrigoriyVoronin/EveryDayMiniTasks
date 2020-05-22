using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arr2SystemSchislen
{
    class Program
    {
        static void Main()
        {
            var baseSystemStart = int.Parse(Console.ReadLine());
            var number = Console.ReadLine();
            var arrayOfNumeral = new int[number.Length];
            var decimalNumber = 0;
            for (int i = 0; i<number.Length; i++)
            {
                arrayOfNumeral[i] = int.Parse(number[i].ToString());
                decimalNumber += arrayOfNumeral[i]* (int)Math.Pow(baseSystemStart, number.Length - (i + 1));
            }
            var baseSystemEnd = int.Parse(Console.ReadLine());
            number = "";
            while(decimalNumber>baseSystemEnd)
            {
                number += (decimalNumber % baseSystemEnd).ToString();
                decimalNumber = decimalNumber / baseSystemEnd;
            }
            number += decimalNumber.ToString();
            number = new string (number.Reverse().ToArray());
            Console.WriteLine(number);
        }
    }
}
