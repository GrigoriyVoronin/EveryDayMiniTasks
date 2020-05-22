using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arr3FractionConverter
{
    class Program
    {
        static void Main()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = (double)a / b;
            string number = c.ToString();
            var str1 = "";
            var indexOfMaxStr = -1;
            var maxLen = 0;
            var str2 = "";
            Console.WriteLine(c);
            for (int i = 2; i < number.Length; i++)
            {
                str1 += number.Substring(i, 1);
                var index = number.Substring(i + 1).IndexOf(str1);

                if (index != -1)
                {
                    maxLen = Math.Max(str1.Length, maxLen);
                    if (str1.Length == maxLen && (str1.Length == 1 || str1[1] != str1[0]))
                    {
                        indexOfMaxStr = i;
                        str2 = str1;
                    }
                }
                else
                    str1 = "";
            }
            while (str2.Length > 1 && str2.IndexOf(str2.Substring(0, 1)) != -1)
            {
                maxLen = 0;
                for (int i = 1; i < str2.Length; i++)
                {
                    if (str2.IndexOf(str2.Substring(0, i)) != -1 && str2.LastIndexOf(str2.Substring(0, i)) != 0)
                    {
                        maxLen = Math.Max(maxLen, i);
                    }
                    else
                        break;
                }
                if (maxLen != 0)
                    str2 = str2.Substring(0, maxLen);
                else
                    break;
            }
            if (indexOfMaxStr != -1)
            {
                if (str2 != number.Substring(2, str2.Length))
                    Console.WriteLine("0.{0}({1})", number.Substring(2, indexOfMaxStr - 2), str2);
                else
                    Console.WriteLine("0.({0})", str2);
            }
            else
                Console.WriteLine(number);
        }
    }
}
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp3
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Числитель:");
//            int a = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Знаменатель:");
//            int b = Convert.ToInt32(Console.ReadLine());
//            int last = 0;
//            string str = "";
//            int ll = -1;
//            int countLL = 0;
//            string end = "";
//            if (a >= b)
//            {
//                end += a / b;
//                int del = a % b;
//                end += (del % b != 0) ? "," : "";
//                while (true)
//                {
//                    if (del % b != 0)
//                    {
//                        del = Convert.ToInt32((del % b) + "0");
//                        if (del % b == ll) countLL += 1; else countLL = 1;
//                        ll = del % b;
//                        if (countLL == 2)
//                        {
//                            /*end[end.Length-1] = '(';
//*/
//                            end.Substring(3, 5);
//                            break;
//                        }
//                        end += del / b;
//                    }
//                    else
//                    {
//                        break;
//                    }
//                }
//            }
//            else
//            {
//                end += "0,";
//                int del = Convert.ToInt32(a + "0");
//                end += del / b;
//                while (true)
//                {
//                    if (del % b != 0)
//                    {
//                        del = Convert.ToInt32((del % b) + "0");
//                        if (del % b == ll) countLL += 1; else countLL = 1;
//                        ll = del % b;
//                        if (countLL == 2)
//                        {
//                            /*end[end.Length-1] = '(';
//*/
//                            end.Substring(end.Length - 4, 3);
//                            break;
//                        }
//                        end += del / b;
//                    }
//                    else
//                    {
//                        break;
//                    }
//                }
//            }
//            Console.WriteLine(end);
//        }
//    }
//}
