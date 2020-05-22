using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arr5Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            var answer = 1;
            foreach (var i in array)
            {
                if (i > answer)
                    break;
                else
                    answer += i;
            }
            Console.WriteLine(answer);
        }
    }
}
