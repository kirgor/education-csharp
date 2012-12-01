using System;
using System.Data.Entity;
using System.Linq;

namespace Practice2
{
    internal class Program
    {
        public class Student
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string LastName { get; set; }

            public bool Sex { get; set; }
        }

        private static void Main(string[] args)
        {
            DbContext context = new DbContext("Data Source = .\\SQLEXPRESS; Initial Catalog = Test; Integrated Security = true");
            var collection = context.Database.SqlQuery<Student>("SELECT * FROM Students").ToList();
            foreach (var item in collection)
            {
                Console.WriteLine("{0} {1}, sex is {2}, ID is {3}", item.Name, item.LastName, item.Sex ? "male" : "female", item.Id);
            }

            TestEntities testContext = new TestEntities();

            foreach (var item in testContext.Database.SqlQuery<Student>("SELECT * FROM Students"))
            {
                Console.WriteLine(item.Name);
            }

            foreach (var item in testContext.Groups)
            {
                Console.WriteLine(item.Motto + ":");
                foreach (var student in item.Students)
                {
                    Console.WriteLine("{0} {1} ({2})", student.Name, student.LastName, item.Head.Name);
                }
            }
        }
    }
}