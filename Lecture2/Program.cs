using System;
using System.Collections.Generic;

namespace Lecture2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Массив
            int[] array = new int[10];
            Array.Sort(array);

            // Список - динамический массив
            List<int> list = new List<int>();
            list.Sort();
            list.Reverse();

            // Стек
            Stack<int> stack = new Stack<int>();
            stack.Push(100);
            stack.Push(200);
            stack.Push(300);

            // Очередь
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);

            // Словарь
            var dic = new SortedDictionary<string, int>();
            dic.Add("one", 1);
            dic.Add("two", 2);
            dic.Add("three", 3);
            dic.Add("four", 4);
            dic.Add("five", 5);
            dic.Add("six", 6);
            dic.Add("seven", 7);

            // Демонстрация словаря
            Console.Write("Input number: ");
            var numberStr = Console.ReadLine().ToLower();
            if (dic.ContainsKey(numberStr))
            {
                Console.WriteLine("You entered {0}", dic[numberStr]);
            }
            else
            {
                Console.WriteLine("I don't know what is {0}", numberStr);
            }
        }
    }
}