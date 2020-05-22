using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arr6_1139
{
    class Program
    {
         public static int Nod(int a, int b)
        {
            while (a > 0 && b > 0)
                if (a > b)
                    a = a % b;
                else
                    b = b % a;
            return a + b;
        }
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine().Split();
            var n = int.Parse(userInput[0])-1;
            var m = int.Parse(userInput[1])-1;
            Console.WriteLine(n + m - Nod(n,m));
        }
    }
}
