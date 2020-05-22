using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Col6
{
    class Program
    {
        public static void DefinePermutations (Dictionary<string,bool> dic, int lenghtSubArr, int [] arrS, int [] arrB)
        {
            //var dic1 = new Dictionary<string, bool>(dic);
            var arrS1 = new int [arrS.Length] ;
            for (int i = 0; i < arrS.Length; i++)
                arrS1[i] = arrS[i];
            for (int i =0; i<arrB.Length-lenghtSubArr;i++)
            {
                var key = "";
                var contain = true;
                for (int j=i;j<i+lenghtSubArr;j++)
                {
                    if (Array.IndexOf(arrS1, arrB[j]) != -1)
                    {
                        arrS1[Array.IndexOf(arrS1, arrB[j])] = 0;
                    }
                    else
                        contain = false;
                    key = i+ " "+ (i+lenghtSubArr);
                }
                for (int k = 0; k < arrS.Length; k++)
                    arrS1[k] = arrS[k];
                dic[key] = contain;
            }
        }
        /*Col6. * Даны два массива из целых чисел от 1 до 100: длины n и длины N(n<N). 
        Определить для каждого подмассива второго массива длины n, является ли он перестановкой первого массива.*/
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());
            var random = new Random();
            var arrS = new int[n];
            var arrB = new int[N];
            for (int i = 0; i < n; i++)
                arrS[i] = random.Next(1, 101);
            for (int i = 0; i < N; i++)
                arrB[i] = random.Next(1, 101);
            var dic = new Dictionary<string, bool>();
            DefinePermutations(dic, n, arrS, arrB);
            Console.WriteLine(dic.Count);
            foreach (var pair in arrS) Console.WriteLine(pair);
            foreach (var pair in arrB) Console.WriteLine(pair);

            foreach (var pair in dic)
                Console.WriteLine(pair);

        }
    }
}
