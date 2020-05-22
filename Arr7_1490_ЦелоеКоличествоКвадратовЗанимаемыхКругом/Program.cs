using System;

namespace _1490_Arr7
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = int.Parse(Console.ReadLine());
            long count = 0;
            for (double x = 0; x < r; x++)
                count += (long)Math.Ceiling(Math.Sqrt((double)r * r - x * x));
            Console.WriteLine(4 * count);
        }
    }
}