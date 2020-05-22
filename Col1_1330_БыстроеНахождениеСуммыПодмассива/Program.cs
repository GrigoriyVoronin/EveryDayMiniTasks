using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col1_1330
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var arrayOfValues = new int[n];
            var sumArray = new int[n];
            for (int i =0; i< n; i++)
            {
                arrayOfValues[i]= int.Parse(Console.ReadLine());
                if (i != 0)
                    sumArray[i] = sumArray[i - 1] + arrayOfValues[i];
                else
                    sumArray[i] = arrayOfValues[i];
            }
            var q = int.Parse(Console.ReadLine());
            var qArray = new int[q][];
            for (int i = 0; i < q; i++)
            {
                var qPair = Console.ReadLine().Split();
                qArray[i] = new int[2];
                qArray[i][0] = int.Parse(qPair[0]);
                qArray[i][1] = int.Parse(qPair[1]);
            }
            for (int i = 0; i < q; i++)
            {
                    Console.WriteLine(sumArray[qArray[i][1]-1] - sumArray[qArray[i][0]-1]+arrayOfValues[qArray[i][0] - 1]);
            }
        }
    }
}
