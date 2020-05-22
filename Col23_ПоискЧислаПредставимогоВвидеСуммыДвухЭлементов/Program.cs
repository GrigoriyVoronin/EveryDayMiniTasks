using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col23
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i=0; i<n;i++)
            {
                arr[i]= int.Parse(Console.ReadLine());
            }
            var x = int.Parse(Console.ReadLine());
            var index1 = 1;
            while(arr[index1]<x)
            {
                index1++;
            }
            var index2 = index1-1;
            while (arr[index1]+arr[index2]>=x)
            {
                index2--;
            }
            for (int i = index2; i<index1; i++)
            {
                for (int j = i+1;j<n;j++)
                {
                    // var stop = false;
                    if (arr[i] + arr[j] == x)
                    {
                        Console.WriteLine("{0}  {1}", i, j);
                        // stop = true;
                        break;
                    }
                }
                // if(stop) break;
            }
        }
    }
}
