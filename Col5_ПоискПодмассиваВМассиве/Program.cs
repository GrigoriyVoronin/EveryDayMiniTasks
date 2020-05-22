using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col5
{
    class Program
    {
        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }
        public static bool ContainsAtIndex(int[] array, int[] subArray, int i)
        {
            bool isIt = true;
            for (int j = 0; j < subArray.Length; j++)
            {
                isIt = isIt && array[i + j] == subArray[j];
            }
            return isIt;
        }
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            var m = int.Parse(Console.ReadLine());
            var subArr = new int[m];
            for (int i = 0; i < m; i++)
            {
                subArr[i] = int.Parse(Console.ReadLine());
            }
            var startIndex = FindSubarrayStartIndex(arr, subArr);
            if (startIndex == -1)
                Console.WriteLine("No");
            else
                Console.WriteLine("Yes");
        }
    }
}
