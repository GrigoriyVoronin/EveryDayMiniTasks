using System;
using System.Linq;

namespace Complex2
{
    class Interval
    {
        public double Start;
        public double End;

        public Interval(double start, double end)
        {
            Start = start;
            End = end;
        }
    }

    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var intervals = new Interval[n];
            for (int i = 0; i < n; i++)
            {
                var pair = Console.ReadLine().Split().Select(x => double.Parse(x)).ToArray();
                intervals[i] = new Interval(pair[0], pair[1]);
            }
            intervals = intervals.OrderBy(interval => interval.Start).ToArray();
            var min = double.MaxValue;
            for (int i = 1; i < n; i++)
            {
                if (intervals[i - 1].End < intervals[i].Start && Calculate(intervals[i].Start,intervals[i - 1].End)>0)
                    if (min > Calculate(intervals[i].Start, intervals[i - 1].End))
                        min = Math.Round(Calculate(intervals[i].Start, intervals[i - 1].End),5);
            }
            Console.WriteLine(min);
        }

        static double Calculate(double numb1,double numb2)
        {
            if (numb1 > 0 && numb2 > 0)
                return numb1 - numb2;
            if (numb1 > 0 && numb2 < 0)
                return numb1 - numb2;
            if (numb1 < 0 && numb2 > 0)
                return 0;
            return Math.Abs(-numb1 + numb2);
        }
    }
}
