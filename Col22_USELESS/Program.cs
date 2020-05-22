using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col22
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());
            //var hod = 0;
            //while (a<=c)
            //{
            //    if (hod % 2 == 0)
            //    {
            //        hod++;
            //        a += b;
            //    }
            //    else
            //    {
            //        hod++;
            //        c -= d;
            //    }
            //}
            // var cost = hod % 2 == 1 ? Math.Min(a, c) : Math.Max(a, c);
            var cost = (double)(c - a) / (b + d);
            cost =a+ Math.Truncate(cost)*b + d*(Math.Ceiling(cost)-Math.Truncate(cost));
            Console.WriteLine(cost);
        }
    }
}
