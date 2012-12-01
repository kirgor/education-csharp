namespace Lecture1
{
    /// <summary>
    /// Класс-реализация класса Person, виден внури сборки
    /// </summary>
    internal class Men : Person
    {
        /// <summary>
        /// Конструктор с параметром, передает параметр базовому конструктору
        /// </summary>
        public Men(int age)
            : base(age)
        { }

        /// <summary>
        /// Перегруженный абстрактный метод
        /// </summary>
        public override string Kick()
        {
            return "^%&@#";
        }
    }
}