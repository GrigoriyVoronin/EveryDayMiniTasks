using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search3
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var lens = new int[n];
            for (var i = 0; i < n; i++)
                lens[n] = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            Array.Sort(lens);
            var number = 0;
            var maxLenght = lens[n-1];
            while (number < k)
            {
                for (int i = n - 1; i > n - k - 1; i++)
                {
                    number += lens[i] / maxLenght;
                }
                number = 0;
                maxLenght--;
            }
            Console.WriteLine(maxLenght);
        }
    }
}
