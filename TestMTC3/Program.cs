using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMTC3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new[] { 1, 2, 3, 4, 5 };
            var intsnew = ints.EnumerateFromTail(3);
            foreach (var item in intsnew)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------");
            List<string> strings = new() { "aaa", "bbb", "ccc", "ddd" };
            var stringsNew = strings.EnumerateFromTail(2);
            foreach (var item in stringsNew)
            {
                Console.WriteLine(item);
            }
        }
    }

    static class Function
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            if (tailLength <= 0 || tailLength == null)
                return new List<(T item, int? tail)>();

            List<(T item, int? tail)> values = new();
            var countCollection = enumerable.Count();
            var currentTailIndex = tailLength;

            if(tailLength >= countCollection)
            {
                foreach (var item in enumerable)
                {
                    currentTailIndex--;
                    values.Add((item, currentTailIndex));
                }
            }
            else
            {
                var startIndexTail = countCollection - tailLength;
                int counter = 0;
                foreach (var item in enumerable)
                {
                    values.Add((item, counter >= startIndexTail ? --currentTailIndex : null));
                    counter++;
                }
            }

            return values;
        }
    }
}