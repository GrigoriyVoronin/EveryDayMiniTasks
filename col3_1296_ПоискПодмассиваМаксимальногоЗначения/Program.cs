using System;

namespace col3_1296
{
    class Program
    {
        static void Main()
        {
            var sumMax = 0;
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i =0; i<n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            if (arr.Length != 0)
            {
                var sum = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (sum > sumMax)
                        sumMax = sum;
                    if (sum + arr[i] > 0)
                        sum += arr[i];
                    else
                        sum = 0;
                }
                if (sum > sumMax)
                    sumMax = sum;
            }
                Console.WriteLine(sumMax);
        }
    }
}
