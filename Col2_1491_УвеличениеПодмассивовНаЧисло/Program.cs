using System;
using System.Text;

namespace Col2_1491
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var awards = new int[n+1];
            for (int i = 0; i < n + 1; i++)
            {
                var trio = Console.ReadLine().Split();
                var j1 = int.Parse(trio[0]) - 1;
                var j2 = int.Parse(trio[1]);
                var j3 = int.Parse(trio[2]);
                awards[j1] += j3;
                awards[j2] -= j3;
            }
            var ans = 0;
            var str = new StringBuilder(n*8);
            for (int i = 0; i < n ; i++)
            {
                ans += awards[i];
                    str.Append(ans);
                    str.Append(" ");
            }
            Console.WriteLine(str.Remove(str.Length-1,1));
        }
    }
}