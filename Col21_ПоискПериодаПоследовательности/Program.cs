using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithArrays;

namespace Col21
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = int.Parse(Console.ReadLine());
            var len = int.Parse(Console.ReadLine());
            var f0 = 0;
            var f1 = 1;
            var posled = new List<int>();
            var period = new List<int>();
            for (int i=0; i<len; i++)
            {
               var f = (f0 + f1) % p;
               // Console.WriteLine(f);
                posled.Add(f);
                f0 = f1;
                f1 = f;
            }

            for (int i =0; i<len/2+1;i++)
            {
                period.Add(posled[i]);
                var isIt = true;
                for (int a =0;a< posled.Count/period.Count;a++)
                {
                        isIt = isIt && posled[a] == period[a % period.Count];
                }
                if (isIt)
                    {
                        Console.WriteLine("Period exists ");
                        foreach (var j in period)
                            Console.WriteLine(j);
                        break;
                    }
            }

            if (period.Count == len / 2)
            {
                Console.WriteLine("Period doesn't esist");
                foreach (var j in period)
                    Console.WriteLine(j);
            }
        }
        }
    }
