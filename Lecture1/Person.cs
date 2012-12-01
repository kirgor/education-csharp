namespace Lecture1
{
    /// <summary>
    /// Абстрактный класс, виден отовсюду
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Поле, видно только из этого класса
        /// </summary>
        private int _weight;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Person(int age)
        {
            Age = age;
        }

        /// <summary>
        /// Свойство
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Еще одно свойство
        /// </summary>
        public int Weight
        {
            get { return _weight; }
            set
            {
                _weight = value > 0 ? value : 0;
            }
        }

        /// <summary>
        /// Виртуальный метод
        /// </summary>
        protected virtual string Name
        {
            get { return "man"; }
        }

        /// <summary>
        /// Обычный метод
        /// </summary>
        public string Hi()
        {
            return "Hi! I'm " + Name + ". I'm " + Age + " years old.";
        }

        /// <summary>
        /// Абстрактный метод
        /// </summary>
        public abstract string Kick();
    }
}