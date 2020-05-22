using System;

class GFG
{
    public static void Main()
    {
        var arr = new long[] { 170, 45, 75, 90, 802, 24, 2, 66 };
        var arr1 = new [] { 170, 45, 75, 90, 802, 24, 2, 66 };
        var n = arr.Length;
        Console.WriteLine(string.Join(" ", SortL(arr)));
        Console.WriteLine(string.Join(" ", Sort(arr1)));
        Console.WriteLine(string.Join(" ", Sort1(arr1)));
    }
    static int[] Sort1(int[] arr)
    {
        int i, j;
        int[] radixArr = new int[arr.Length];
        int[] radixNumberArr = new int[arr.Length];
        int[] counterArr;
        int[] indexArr = new int[256];
        for (int shift = 0; shift < 4; shift++)
        {
            counterArr = new int[256];
            for (i = 0; i < arr.Length; i++)
            {
                j = (arr[i] >> (shift * 8)) % 256;
                counterArr[j]++;
                radixArr[i] = j;
                radixNumberArr[i] = arr[i];
            }
            indexArr[0] = 0;
            for (i = 1; i < counterArr.Length; i++)
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
    static int[] Sort(int[] old)
    {
        int i, j;
        int[] tmp = new int[old.Length];
        for (int shift = 31; shift > -1; --shift)
        {
            j = 0;
            for (i = 0; i < old.Length; ++i)
            {
                bool move = (old[i] << shift) >= 0;
                if (shift == 0 ? !move : move)  // shift the 0's to old's head
                    old[i - j] = old[i];
                else                            // move the 1's to tmp
                    tmp[j++] = old[i];
            }
            Array.Copy(tmp, 0, old, old.Length - j, j);
        }
        return old;
    }

    public static long[] SortL(long[] arr)
    {
        if (arr == null || arr.Length == 0)
            return arr;

        int i, j;
        var tmp = new long[arr.Length];
        for (int shift = sizeof(long) * 8 - 1; shift > -1; --shift)
        {
            j = 0;
            for (i = 0; i < arr.Length; ++i)
            {
                var move = (arr[i] << shift) >= 0;
                if (shift == 0 ? !move : move)
                    arr[i - j] = arr[i];
                else
                    tmp[j++] = arr[i];
            }
            Array.Copy(tmp, 0, arr, arr.Length - j, j);
        }

        return arr;
    }
}