using System;
using System.Collections.Generic;

namespace TestMTC4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3, 5, 2, 2, 9, 7, 5, 8, 4, 3, 10, 7, 9, 12 };

            foreach (var item in ints)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\n");
            var Sorted = Sort(ints, 5, 8);

            foreach (var item in Sorted)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            List<int> sortedList = new List<int>(inputStream);

            //Errors
            foreach (var item in sortedList)
            {
                if (item < 0)
                {
                    Console.WriteLine("Error");
                    return sortedList;
                }
            }
            if (sortedList.Count > MathF.Pow(10,9))
            {
                Console.WriteLine("Error");
                return sortedList;
            }

            int downBoardDelete = 0;

            sortedList.RemoveAll(x => x > maxValue);

            foreach (var item in inputStream)
            {
                if (item > downBoardDelete)
                {
                    if(downBoardDelete >= 0 && (item - sortFactor) > 0)
                    {
                        downBoardDelete = item - sortFactor;
                        sortedList.RemoveAll(x => x < downBoardDelete);
                    }
                }
            }

            //Sort
            for (int i = 0; i < sortedList.Count; i++)
            {
                var idMin = i;
                for (int j = i + 1; j < sortedList.Count; j++)
                {
                    if (sortedList[j] < sortedList[idMin])
                        idMin = j;
                }
                var tmp = sortedList[idMin];
                sortedList[idMin] = sortedList[i];
                sortedList[i] = tmp;
            }

            return sortedList;
        }

    }
}