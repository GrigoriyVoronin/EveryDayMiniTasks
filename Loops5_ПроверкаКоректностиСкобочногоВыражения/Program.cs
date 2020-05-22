using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops5Skobki
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var sum = 0;
            for (int i = 0; i<str.Length; i++)
            {
                if (str[i] == '(')
                {
                    sum++;
                }
                else
                {
                    sum--;
                    if (sum <0)
                    {
                        break;
                    }
                }
            }
            if (sum == 0)
                Console.WriteLine("AC");
            else
                Console.WriteLine("WA");
        }
    }
}
