using System;

namespace Lecture1
{
	internal class Program
	{
		/// <summary>
		/// Точка входа в программу
		/// </summary>
		private static void Main(string[] args)
		{
			//Person p = new Person(); Ошибка - нельзя создавать экземпляры абстрактных классов

			//Массив элементов типа Person
			Person[] peoples = { new Men(40), new Women(), new Men(15), new Men(23), new Women() };

			// Назначение свойств
			peoples[0].Weight = 10;
			peoples[1].Weight = -100;

			// Вызов статического метода WriteLine класса статического Console (переведите на него курсор и нажмите F12)
			Console.WriteLine("Weight of the 1st person is " + peoples[0].Weight);
			Console.WriteLine("Weight of the 2nd person is " + peoples[1].Weight);
			Console.WriteLine();

			// Цикл о котором я не рассказывал, пробегает по всем элементам
			foreach (Person p in peoples)
			{
				Console.WriteLine(p.Hi());
				Console.WriteLine("THIS IS SPARTA!!! <kick person>");
				Console.WriteLine(p.Kick());
				Console.WriteLine();
			}
		}
	}
}