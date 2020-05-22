using System;
using System.Linq;

namespace krugi
{

    class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var timeInSec = new int[n];
            for (int i = 0; i < n; i++)
            {
                var d = Console.ReadLine().Split(':');
                timeInSec[i] = int.Parse(d[0]) * 3600 + int.Parse(d[1]) * 60 + int.Parse(d[2]);
            }
            Array.Sort(timeInSec);

            var timeInRoad = new long[n];
            for (int i = 1; i < n; i++)
                timeInRoad[0] += i * (timeInSec[i] - timeInSec[i - 1]);

            if (n > 1)
                timeInRoad[1] = timeInRoad[0] - (timeInSec[n - 1] - timeInSec[0]) + (n - 1) * (43200 - timeInSec[n - 1] + timeInSec[0]);

            for (int i = 2; i < n; i++)
                timeInRoad[i] = timeInRoad[i - 1] - (43200 - timeInSec[i - 1] + timeInSec[i - 2]) + (n - 1) * (timeInSec[i - 1] - timeInSec[i - 2]);

            var an = (Array.IndexOf(timeInRoad, timeInRoad.Min()) - 1);
            var index = an == -1 ? n - 1 : an;

            var sec = timeInSec[index] % 60;
            var min = timeInSec[index] % 3600 / 60;
            var hours = timeInSec[index] / 3600;
            Console.WriteLine("{0:0}:{1:00}:{2:00}", hours, min, sec);
        }
    }
}