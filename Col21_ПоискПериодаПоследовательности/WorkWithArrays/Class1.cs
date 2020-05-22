using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithArrays
{
    public static class SearchInArray
    {
        public static int FindSubarrayStartIndex(int[] array, int[] subArray, int start)
        {
            for (var i = start; i < array.Length - subArray.Length + 1; i++)
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
    }
}
