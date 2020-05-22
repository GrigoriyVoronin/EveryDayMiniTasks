using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec4_1603_2
{
    class Program
    {
        public static char[,] Table = new char[4, 4];
        public static string[] Words;
        public static bool[] WordsIs;
        static void Main()
        {
            for (int i = 0; i < 4; i++)
            {
                var str = Console.ReadLine();
                for (int j = 0; j < 4; j++)
                    Table[i, j] = str[j];
            }
            var count = int.Parse(Console.ReadLine());
            Words = new string[count];
            WordsIs = new bool[count];
            for (int i = 0; i < count; i++)
            {
                Words[i] = Console.ReadLine();
                Check(i);
                Console.WriteLine("{0}: {1}", Words[i], WordsIs[i] ? "YES" : "NO");
            }
        }

        private static void Check(int index)
        {
            if (!ContainedAll(Words[index]))
                return;
            FindWord(index);
        }

        private static void FindWord(int index)
        {
            var placeTable = new bool[4, 4];
            var word1 = new char[16];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (Table[i, j] == Words[index][0])
                    {
                        word1[0] = Table[i, j];
                        Looking(i, j, placeTable, index, word1, 1);
                    }
                }
        }

        private static void Looking(int x, int y, bool[,] placeTable, int index, char[] word1, int n)
        {

            if (Words[index].Length >= n && Words[index][n - 1] == word1[n - 1])
            {
                if (Words[index].Length == n)
                {
                    WordsIs[index] = true;
                }
                else
                {
                    Rec(x, y, Clone(placeTable), index, word1, n + 1);
                }
            }
        }

        private static bool ContainedAll(string word)
        {
            for (int i = 0; i < word.Length; i++)
                if (!Contained(word[i]))
                    return false;
            return true;
        }

        private static bool Contained(char letter)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (Table[i, j] == letter)
                        return true;
            return false;
        }
        public static void Virt(int x, int y, bool[,] placingTable, int index, char[] word, int n)
        {
            if (!placingTable[x, y])
            {
                word[n - 1] = Table[x, y];
                Looking(x, y, placingTable, index, word, n);
            }

        }
        public static void VirtX(int x, int y, bool[,] placingTable, int index, char[] word, int n)
        {
            if (y == 0)
            {
                Virt(x, y + 1, placingTable, index, word, n);
            }
            else if (y == 3)
            {
                Virt(x, y - 1, placingTable, index, word, n);
            }
            else
            {
                Virt(x, y + 1, placingTable, index, word, n);
                Virt(x, y - 1, placingTable, index, word, n);
            }
        }
        public static void Rec(int x, int y, bool[,] placingTable, int index, char[] word, int n)
        {
            placingTable[x, y] = true;

            if (x == 0)
            {
                VirtX(x, y, placingTable, index, word, n);
                Virt(x + 1, y, placingTable, index, word, n);
                return;
            }
            if (x == 1)
            {
                VirtX(x, y, placingTable, index, word, n);
                Virt(x + 1, y, placingTable, index, word, n);
                Virt(x - 1, y, placingTable, index, word, n);
                return;
            }
            if (x == 2)
            {
                VirtX(x, y, placingTable, index, word, n);
                Virt(x + 1, y, placingTable, index, word, n);
                Virt(x - 1, y, placingTable, index, word, n);
                return;
            }
            if (x == 3)
            {
                VirtX(x, y, placingTable, index, word, n);
                Virt(x - 1, y, placingTable, index, word, n);
                return;
            }
        }

        public static bool[,] Clone(bool[,] arr)
        {
            var arr1 = new bool[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    arr1[i, j] = arr[i, j];
            return arr1;
        }
    }
}