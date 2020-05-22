using System;

namespace Loops3
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var str = "";
            var count = 1;
            while (str.Length < n)
            { 
                str += count;
                count++;
            }
            Console.WriteLine(str[n]);
        }
    }
}
