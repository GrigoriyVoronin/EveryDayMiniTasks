using System;
using System.Diagnostics;

namespace Rec1_ВозведениеВСтепень
{
    class Program
    {
        static void PowWithOut(double number, int pow)
        {
            var time = new Stopwatch();
            time.Start();
            double chislo = 1;
            var stepeni = new double[pow + 1];
            stepeni[0] = chislo;
            for (int i = 0; i < pow; i++)
            {
                if (stepeni[i] != 0 && i != 0 && pow % i == 0 && i + i <= pow)
                {
                    chislo *= stepeni[i];
                    i += i - 1;
                    stepeni[i + 1] = chislo;
                    continue;
                }

                chislo *= number;
                stepeni[i + 1] = chislo;
            }

            time.Stop();
            Console.WriteLine(stepeni[pow] + " " + time.Elapsed.TotalMilliseconds);
        }

        static void PowWith(double number, int pow)
        {
            var time = new Stopwatch();
            time.Start();
            var stepeni = new double[pow + 1];
            stepeni[0] = 1;
            var chislo = Vozdevi(number, pow, stepeni, 0, stepeni[0]);
            time.Stop();
            Console.WriteLine(chislo + " " + time.Elapsed.TotalMilliseconds);
        }

        static double Vozdevi(double number, int pow, double[] stepeni, int curPow, double chislo)
        {
            if (stepeni[curPow] != 0 && curPow != 0 && pow % curPow == 0 && 2 * curPow <= pow)
            {
                chislo *= stepeni[curPow];
                curPow += curPow;
                stepeni[curPow] = chislo;
                return Vozdevi(number, pow, stepeni, curPow, chislo);
            }
            else if (pow != curPow)
            {
                chislo *= number;
                curPow++;
                stepeni[curPow] = chislo;
                return Vozdevi(number, pow, stepeni, curPow, chislo);
            }
            else
                return chislo;
        }

        static void SimplePowWith(double number, int pow)
        {
            var time = new Stopwatch();
            time.Start();
            var chislo = VozvediSimple(number, pow, 1, 0);
            time.Stop();
            Console.WriteLine(chislo + " " + time.Elapsed.TotalMilliseconds);
        }

        static double VozvediSimple(double number, int pow, double chislo, int curPow)
        {
            if (pow == curPow)
                return chislo;
            else
            {
                chislo *= number;
                curPow++;
                return VozvediSimple(number, pow, chislo, curPow);
            }
        }

        private static void SimplePowWithOut(double number, int pow)
        {
            var time = new Stopwatch();
            time.Start();
            var curPow = 0;
            var chislo = 1.0;
            while (curPow != pow)
            {
                chislo *= number;
                curPow++;
            }

            time.Stop();
            Console.WriteLine(chislo + " " + time.Elapsed.TotalMilliseconds);
        }
        private static void Fibanachi ( int pow)
        {
            var time = new Stopwatch();
            time.Start();
            var matrix = new long [,] { { 1, 1 }, { 1, 0 } };
            var matrixAns = new long[,] { { 1, 1 }, { 1, 0 } };

            if (pow == 0)
                    Console.WriteLine(matrixAns[1,1]);
                else if (pow ==1)
                Console.WriteLine(matrixAns[0,1]);
            else if (pow == 2)
                Console.WriteLine(matrixAns[0,0]);
            else
                {
                    var curPow = 1;
                pow -= 1;
                    while (curPow != pow)
                    {
                        if (curPow * 2 <= pow)
                        {
                        matrixAns= MatrixMultiply(matrixAns, matrixAns);
                            curPow *= 2;
                        }
                        else
                        {
                            curPow++;
                        matrixAns = MatrixMultiply(matrixAns, matrix);
                        }
                    }
                time.Stop();
                Console.WriteLine(matrixAns[0,0] + " " + time.Elapsed.TotalMilliseconds);
            }
        }

        private static void FibanachiRec(ref int pow,ref int curPow,ref long[,] matrix,ref long[,] matrixAns)
        {
            if (pow == 0)
                Console.WriteLine(matrixAns[1, 1]);
            if (pow == 1)
                Console.WriteLine(matrixAns[0, 1]);
            if (curPow == pow-1)
                {
                    Console.WriteLine(matrixAns[0, 0]);
                }
            else
                {
                    if (curPow * 2 <= pow)
                    {
                    curPow *= 2;
                    matrixAns = MatrixMultiply(matrixAns, matrixAns);
                        FibanachiRec(ref pow,ref curPow,ref matrix,ref matrixAns);
                    }
                    else
                    {
                    curPow++;
                    matrixAns = MatrixMultiply(matrixAns, matrix);
                        FibanachiRec(ref pow, ref curPow, ref matrix, ref matrixAns);
                    }
                }
        }


        private static long[,] MatrixMultiply(long[,] matrix1,long[,] matrix2)
        {
            var matrixAns = new long[2, 2];

            for (int i=0; i< matrix1.GetLength(0);i++)
            {
                for (int j=0; j<matrix2.GetLength(1); j++)
                {
                    for (int x = 0; x < matrix1.GetLength(0); x++)
                    {
                        matrixAns[i, j] += matrix1[i, x] * matrix2[x, j];
                    }
                }
            }
            return matrixAns;
        }
        static void Main()
        {
            var number = double.Parse(Console.ReadLine());
            var pow = int.Parse(Console.ReadLine());
            Console.WriteLine("NeРекурс");
            PowWithOut(number, pow);
            Console.WriteLine("Рекурс");
            PowWith(number, pow);
            Console.WriteLine("Рекурс");
            SimplePowWith(number, pow);
            Console.WriteLine("NeРекурс");
            SimplePowWithOut(number, pow);
            Console.WriteLine("NeРекурс");
            Pow1(number, pow);
            Console.WriteLine("Рекурс");
            Pow2(number, pow);
            while (true)
            { 
            var i = int.Parse(Console.ReadLine());
            Console.WriteLine("Фибоначи Нерекурсивно");
            Fibanachi(i);
            var time = new Stopwatch();
            time.Start();
            var matrix = new long[,] { { 1, 1 }, { 1, 0 } };
            var matrixAns = new long[,] { { 1, 1 }, { 1, 0 } };
            Console.WriteLine("Фибоначи Рекурсивно");
            var one = 1;
            FibanachiRec(ref i, ref one, ref matrix, ref matrixAns);
            time.Stop();
            Console.Write(" " + time.Elapsed.TotalMilliseconds);
            }
        }

        

        private static void Pow1(double number, int pow)
        {
            var time = new Stopwatch();
            time.Start();
            var chislo = number;
            if (pow == 0)
                chislo = 1;
            else
            {
                var curPow = 1;
                while (curPow != pow)
                {
                    if (curPow * 2 <= pow)
                    {
                        chislo *= chislo;
                        curPow *= 2;
                    }
                    else
                    {
                        curPow++;
                        chislo *= number;
                    }
                }
            }

            time.Stop();
            Console.WriteLine(chislo + " " + time.Elapsed.TotalMilliseconds);
        }

        private static void Pow2(double number, int pow)
        {
            var time = new Stopwatch();
            time.Start();
            var chislo = 1.0;
            if (pow != 0)
            {
                chislo = Vozv2(number, pow, number, 1);
            }

            time.Stop();
            Console.WriteLine(chislo + " " + time.Elapsed.TotalMilliseconds);
        }

        static double Vozv2(double number, int pow, double chislo, int curPow)
        {
            if (curPow != pow)
            {
                if (curPow * 2 <= pow)
                {
                    chislo = Vozv2(number, pow, chislo * chislo, 2 * curPow);
                }
                else
                {
                    chislo = Vozv2(number, pow, chislo * number, curPow + 1);
                }
            }

            return chislo;
        }
    }
}
