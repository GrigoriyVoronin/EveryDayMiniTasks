using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col7
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (var i =0; i<n;i++)
                arr[i] = int.Parse(Console.ReadLine()); ;
            Array.Sort(arr);
            Console.WriteLine(arr[n / 2]);
        }
    }
}
