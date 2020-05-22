using System;

namespace Cond1_7
{
    class Program
    {
        public static string WriteAnswer(bool IsItCorrect)
        {
            return (IsItCorrect) ? "Корректный ход": "НЕПРАВИЛЬНЫЙ ХОД";
        }
        public static string IsItcorrectMove(string start, string end, string name)
        {
            switch(name)
            {
                case "слон" :
                        return WriteAnswer(end[0] - start[0] == end[1] - start[1] && end[1] - start[1] != 0);
                case "король":
                        return WriteAnswer((end[0] - start[0] == end[1] - start[1] && end[0] - start[0] == 1) 
                            || (end[0] - start[0] == 1 && end[1] - start[1] == 0)
                        || (end[1] - start[1] == 1 && end[0] - start[0] == 0));
                case "ферзь":
                        return WriteAnswer((end[0] - start[0] == end[1] - start[1] && end[0] - start[0] != 0) 
                            || (end[0] - start[0] != 0 && end[1] - start[1] == 0)
                        || (end[0] - start[0] == 0 && end[1] - start[1] != 0));
                case "конь":
                        return WriteAnswer((Math.Abs(end[0] - start[0]) == 2 && Math.Abs(end[1] - start[1]) == 1)
                        || (Math.Abs(end[1] - start[1]) == 2 && Math.Abs(end[0] - start[0]) == 1));
                case "ладья":
                    return WriteAnswer((end[0] - start[0] == 0 && end[1]-start[1] !=0)
                            || (end[0] - start[0] != 0 && end[1] - start[1] == 0));
                default:
                        return "Unknown figure";
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коардинаты начальной клетки и конечной клетки, через пробел: ");
            var userInput = Console.ReadLine().Split();
            var start = userInput[0];
            var end = userInput[1];
            Console.WriteLine("Введите название фигуры: слон/король/ферзь/конь/ладья");
            var name = Console.ReadLine();
            Console.WriteLine(IsItcorrectMove(start, end,name));
        }
    }
}
