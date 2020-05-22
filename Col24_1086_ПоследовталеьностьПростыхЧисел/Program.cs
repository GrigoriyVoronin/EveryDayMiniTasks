using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col24_1086
{
    class Program
    {
        public static int FindNextSimpleNumber (int number,int[] simpleNumbers,int index)
        {
            var nextNumber = number+2;

            bool stop = true;
            while (stop)
            {
                for (int i=0;i<index;i++)
                {
                    if (nextNumber%simpleNumbers[i] ==0)
                    {
                        nextNumber+=2;
                        break;
                    }
                    else if (i == index-1)
                    {
                        stop = false;
                        break;
                    }
                }
            }
            return nextNumber;
        }
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new int[n];
            var simpleNumbers = new int[n];
            simpleNumbers[0] = 2;
            simpleNumbers[1] = 3;
            var index = 2;
            while (index < n)
            {
                simpleNumbers[index] = FindNextSimpleNumber(simpleNumbers[index-1],simpleNumbers,index);
                index++;
            }
            foreach (var i in numbers)
                Console.WriteLine(simpleNumbers[i-1]);
        }
    }
}
