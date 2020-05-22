using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1026_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for(int i =0; i<n;i++)
                arr[i]= int.Parse(Console.ReadLine());
            Console.ReadLine();
            var k = int.Parse(Console.ReadLine());
            Sort(arr);
            for (int i = 0; i < k; i++)
                Console.WriteLine(arr[int.Parse(Console.ReadLine()) - 1]);
        }
        static int[] Sort(int[] arr)
        {
            int i, j;
            int[] radixArr = new int[arr.Length];
            int[] radixNumberArr = new int[arr.Length];
            int[] counterArr;
            int[] indexArr = new int[256];
            for (int shift = 0; shift <4; shift++)
            {
                counterArr = new int[256];
                for (i=0;i<arr.Length;i++)
                {
                    j = (arr[i] >> (shift * 8)) % 256;
                    counterArr[j]++;
                    radixArr[i] = j;
                    radixNumberArr[i] = arr[i];
                }
                indexArr[0] = 0;
                for (i=1;i<counterArr.Length;i++)
                {
                    j = i - 1;
                    indexArr[i] = counterArr[j] + indexArr[j];
                }
                for (i = 0; i < arr.Length; i++)
                {
                    arr[indexArr[radixArr[i]]] = radixNumberArr[i];
                    indexArr[radixArr[i]]++;
                }
            }
            return arr;
        }
    }
}
