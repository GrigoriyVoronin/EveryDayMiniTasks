using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops4
{
    class Program
    {
        static void Main(string[] args)
        {
            var mas = new double[int.Parse(Console.ReadLine())];
            for (int i= 0; i<mas.Length; i++)
            {
                mas[i] =double.Parse(Console.ReadLine());
            }
            var count = 1;
            var element = mas[0];
            var max = 1;
            for (int i =1; i< mas.Length; i++)
            {
                if (mas[i] == mas[i - 1])
                {
                    count++;
                    max = Math.Max(max, count);
                }
                else
                    count = 1;
            }
            Console.WriteLine(max);
        }
    }
}
