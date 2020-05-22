using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col4
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for(int i =0; i< n; i++)
            {
                arr[i]= int.Parse(Console.ReadLine());
            }
            var m = int.Parse(Console.ReadLine());
            var maxSum = 0;
            var sum = 0;
            var startIndex = 0;
            for (int j = 0; j < m; j++)
            {
                maxSum += arr[j];
            }
            for (int i =0; i<n-m+1;i++)
            {
                for (int j = i; j < i+m; j++)
                {
                    sum += arr[j];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    startIndex = i;
                }
                sum = 0;
            }
            for (int i =0; i <m;i++)
            {
                Console.WriteLine(arr[startIndex + i]);
            }
        }
    }
}
