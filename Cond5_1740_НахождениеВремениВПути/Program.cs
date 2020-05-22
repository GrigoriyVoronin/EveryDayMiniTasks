using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Олени_лучше
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine().Split();
            var l = int.Parse(userInput[0]);
            var k = int.Parse(userInput[1]);
            var h = int.Parse(userInput[2]);
            var v = l / k;
            if (v  == Math.Ceiling((double)l/k))
            {
                    Console.Write(v*h);
                    Console.Write(" ");
                    Console.Write(v*h);
            }
            else if (v < Math.Ceiling((double)l/k))
            {
                Console.Write(v*h);
                Console.Write(" ");
                Console.Write((v+1)*h);
            }
        }
    }
}
