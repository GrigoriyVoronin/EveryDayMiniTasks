using System;

namespace Arr4Arrays
{
    class Program
    {
        public static int [] CreateCombinedArray(int[] arr1, int[] arr2)
        {
            Console.WriteLine("Объединение массивов");
            var lenghtArray = arr1.Length + arr2.Length;
            var arrayCombined = new int[lenghtArray];
            

            if (arr1[arr1.Length - 1] < arr2[arr2.Length - 1])
                CombinedArrays(arr1, arr2, arrayCombined);
            else
                CombinedArrays(arr2, arr1, arrayCombined);
            foreach (var a in arrayCombined)
                Console.WriteLine(a);
            return arrayCombined;
        }

        public static void CombinedArrays(int [] arr1, int [] arr2, int [] arrayCombined)
        {
            var i = 0;
            var j = 0;
            while (i < arr1.Length || j < arr2.Length)
            {
                if (i != arr1.Length && arr1[i] <= arr2[j])
                {
                    arrayCombined[i + j] = arr1[i];
                    i++;
                }
                else
                {
                    arrayCombined[i + j] = arr2[j];
                    j++;
                }
            }
        }

        public static int [] CreateIntersectionArray(int[] arr1, int[] arr2)
        {
            Console.WriteLine("Перессечение массивов");
            var lenghtArray = Math.Min(arr1.Length, arr2.Length);
            var arrayIntersection1 = new int[lenghtArray];
            if (arr1.Length > arr2.Length)
                FindIntersection(arr2, arr1, arrayIntersection1, out lenghtArray);
            else
                FindIntersection(arr1, arr2, arrayIntersection1, out lenghtArray);

            if (lenghtArray == 0)
            {
                Console.WriteLine("Пустое множество");
                return new int[lenghtArray];
            }
            else if (lenghtArray == arrayIntersection1.Length)
            {
                foreach (var a in arrayIntersection1)
                    Console.WriteLine(a);
                return arrayIntersection1;
            }
            else
            {
                var arrayIntersection2 = new int[lenghtArray];
                for (int i = 0; i < lenghtArray; i++)
                {
                    arrayIntersection2[i] = arrayIntersection1[i];
                }
                foreach (var a in arrayIntersection2)
                    Console.WriteLine(a);
                return arrayIntersection2;
            }
        }

        public static void FindIntersection(int[] arr1, int[] arr2, int[] arr3, out int numberOfElements)
        {
            numberOfElements = 0;

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i] == arr1[j])
                    {
                        arr3[j] = arr1[j];
                        numberOfElements++;
                    }
                }
            }
            numberOfElements = Math.Min(arr3.Length, numberOfElements);
        }
        public static int [] CreateDifferenceArray(int[] arr1, int[] arr2, int [] intersectionArray)
        {
            var arrayLenght = arr1.Length - intersectionArray.Length;
            var differnceArray = new int[arrayLenght];
            var index = 0;
            Console.WriteLine("Разность массивов");
            if (intersectionArray.Length == 0)
            {
                foreach (var a in arr1)
                    Console.WriteLine(a);
                return arr1;
            }
            else if (arrayLenght == 0)
            {
                Console.WriteLine("Путсое множество");
                return new int[arrayLenght];
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    if (Array.IndexOf(intersectionArray, arr1[i]) != -1)
                    {
                        differnceArray[index] = arr1[i];
                    }

                }
                foreach (var a in differnceArray)
                    Console.WriteLine(a);
                return differnceArray;
            }
            
        }

        static void Main(string[] args)
        {
            var n1 = int.Parse(Console.ReadLine());
            var n2 = int.Parse(Console.ReadLine());
            var arr1 = new int[n1];
            var arr2 = new int[n2];
            for (int i = 0; i < n1; i++)
                arr1[i] = int.Parse(Console.ReadLine());
            for (int i = 0; i < n2; i++)
                arr2[i] = int.Parse(Console.ReadLine());
            var  combinedArray =  CreateCombinedArray(arr1, arr2);
            var intersectionArray = CreateIntersectionArray(arr1, arr2);
            var differenceArray = CreateDifferenceArray(arr1, arr2, intersectionArray);
        }
    }
}
