using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARLb1
{
    /// <summary>
    /// Класс, описывающий персону: имя, фамилию, возраст и пол.
    /// </summary>
    public class Person
    {
        // Поля (можно использовать свойства напрямую — это более идиоматично в C#)
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="surname">Фамилия человека.</param>
        /// <param name="age">Возраст (должен быть >= 0).</param>
        /// <param name="sex">Пол человека.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если возраст отрицательный.</exception>
        public Person(string name, string surname, int age, Sex sex)
        {
            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.", nameof(age));

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// Переопределение метода ToString для удобного отображения объекта.
        /// </summary>
        /// <returns>Строковое представление Person.</returns>
        public override string ToString()
        {
            return $"{Name} {Surname}, {Age} лет, пол: {Sex}";
        }
    }
}