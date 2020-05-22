using System;
using System.Linq;
namespace Col25_1645
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split();
            var arrTimeReal = new int[n];
            for (int i = 0; i < n; i++)
                arrTimeReal[int.Parse(arr[i]) - 1] = i + 1;
            for (int i = 0; i < n; i++)
            {
                var counter1 = 0;
                for (int j = i; j > 0; j--)
                    if (arrTimeReal[j-1] < arrTimeReal[i]) counter1++;
                Console.Write(arrTimeReal[i]-counter1);
                Console.Write(" ");
                counter1 = 0;
                for (int j = i; j < n - 1; j++)
                    if (arrTimeReal[j + 1] > arrTimeReal[i]) counter1++;
                Console.Write(arrTimeReal[i] + counter1);
                Console.WriteLine();
            }  
        }
    }
}