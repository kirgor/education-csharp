namespace Lecture1
{
	/// <summary>
	/// Класс-реализация класса Person, виден внури сборки
	/// </summary>
	internal class Women : Person
	{
		/// <summary>
		/// Пустой конструктор, который вызывает базовый со значением 18
		/// </summary>
		public Women()
			: base(18)
		{ }

		/// <summary>
		/// Перегруженное виртуальное свойство
		/// </summary>
		protected override string Name
		{
			get { return "women"; }
		}

		/// <summary>
		/// Перегруженный абстрактный метод
		/// </summary>
		public override string Kick()
		{
			return "Oh, my God!";
		}
	}
}