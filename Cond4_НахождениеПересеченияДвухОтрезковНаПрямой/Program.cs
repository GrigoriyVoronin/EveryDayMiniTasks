using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond4
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine().Split();
            var a = double.Parse(userInput[0]);
            var b = double.Parse(userInput[1]);
            var c = double.Parse(userInput[2]);
            var d = double.Parse(userInput[3]);
            if (a <= c)
            {
                if (b > c && b > d)
                    Console.WriteLine(d - c);
                else if (b > c && b < d)
                    Console.WriteLine(b - c);
                else
                    Console.WriteLine(0);
            }
            else
            {
                if (d > a && d > b)
                    Console.WriteLine(b - a);
                else if (d > a && d < b)
                    Console.WriteLine(d - a);
                else
                    Console.WriteLine(0);
            }
        }
    }
}
