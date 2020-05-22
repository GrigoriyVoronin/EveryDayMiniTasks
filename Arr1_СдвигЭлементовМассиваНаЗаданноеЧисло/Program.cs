using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arr1SdvigMassiva
{
    class Program
    {
        /*
         * Reverse(array, 0, k-1);  // O(k)​

Reverse(array, k, n-1);  // O(n-k)​

Reverse(array, 0, n-1);  // O(n)*/

        static void Main(string[] args)
        {
             var n = int.Parse(Console.ReadLine());
            var masiv = new int[n];

            for (int i = 0; i< n; i++)
            {
                masiv[i] = int.Parse(Console.ReadLine());
            }

            var k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                for (int j=0; j<n-1; j++)
                {
                    int a = masiv[j + 1];
                    masiv[j + 1] = masiv[0];
                    masiv[0] = a;
                }
            }

            for (int i =0; i < n; i++)
            {
                Console.WriteLine(masiv[i]);
            }
        }
    }
}
