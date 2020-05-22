using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersiniKvadrata
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine().Split();
            var b = Console.ReadLine().Split();
            var c = Console.ReadLine().Split();
            var ax = int.Parse(a[0]);
            var ay = int.Parse(a[1]);
            var bx = int.Parse(b[0]);
            var by = int.Parse(b[1]);
            var cx = int.Parse(c[0]);
            var cy = int.Parse(c[1]);
            if ((ax == cx|| ax == bx || bx == cx)
                && (ay == cy || ay == by || by== cy))
            {
                Console.WriteLine("Eto kvarat");
                if (ax == bx)
                    Console.WriteLine(cx);
                else if (ax == cx)
                    Console.WriteLine(bx);
                else
                    Console.WriteLine(ax);
                if (ay == by)
                    Console.WriteLine(cy);
                else if (ay == cy)
                    Console.WriteLine(by);
                else
                    Console.WriteLine(ay);
            }
            else
                Console.WriteLine("Eto ne kvadrat");
        }
    }
}
