using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond2
{
    class Program
    {
        public static void WriteAnswer(bool IsItCorrect)
        {
            Console.WriteLine( (IsItCorrect) ? "Корректный ход" : "НЕПРАВИЛЬНЫЙ ХОД");
        }
        static void Main(string[] args)
        {
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());
            var z = double.Parse(Console.ReadLine());
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());
            var minSide = Math.Min(x, Math.Min(y, z));
            var maxSide = Math.Max(x, Math.Max(y, z));
            var midSide = x + y + z - minSide- maxSide;
            WriteAnswer(minSide<=Math.Min(a,b) && midSide<=Math.Max(a,b));
        }
    }
}
