using System;
using System.Globalization;

namespace _1484Kino
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine().Split();
            var x = double.Parse(userInput[0],CultureInfo.InvariantCulture);
            var y = double.Parse(userInput[1], CultureInfo.InvariantCulture);
            var n = int.Parse(userInput[2], CultureInfo.InvariantCulture);
            double xItog = 0;

            int ans = 0;
            if (x != 10.0)
            {
                xItog = (int)((x + 0.05) * n);
                while (xItog / n >= x + 0.049999999999) xItog--;
            }
            else
            {
                xItog = x * n;
            }
            int count = 0;
            if (((ans + xItog) / (ans + n)) >= y + 0.0499999999999)
            {
                ans = 1;
                while (((ans + xItog) / (ans + n)) >= y + 0.0499999999999)
                {
                    count++;
                    ans *= 2;
                }
                ans = (int)Math.Pow(2, count-1);
                while (((ans + xItog) / (ans + n))  >= y + 0.0499999999999)
                {
                    ans++;
                }
            }
                Console.WriteLine(ans);
        }
    }
}
