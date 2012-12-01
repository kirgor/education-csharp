using System;
using System.Collections.Generic;
using System.Linq;
using MathFunc = System.Func<double, double>;

namespace Lecture4
{
    internal class Program
    {
        private class Person
        {
            public int Age { get; set; }

            public string Name { get; set; }

            public override string ToString()
            {
                return String.Format("{0}, {1} years old", Name, Age);
            }
        }

        private static void Main(string[] args)
        {
            MathFunc f1 = x => x * x;
            MathFunc f2 = x => Math.Cos(x) * 4;
            double y1 = f1(10);
            double y2 = f2(2.5);

            var list = new List<Person>();
            var rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(new Person { Age = rand.Next(10000), Name = (char)rand.Next((int)'A', (int)'Z' + 1) + "asha" });
            }

            double avg = list.Average<Person>(p => p.Age);

            var list2 = new List<Person>();

            var array = list.Where(p => p.Name == "Pasha").ToList();
            foreach (var item in list.Where(p => p.Name == "Pasha"))
            {
                Console.WriteLine(item);
            }
        }
    }
}