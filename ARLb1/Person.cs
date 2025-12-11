using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ARLb1
{
        /// <summary>
        /// Класс, описывающий персону: имя, фамилию, возраст и пол.
        /// </summary>
        public class Person
    {
        // === Свойства ===

        /// <summary>
        /// Имя персоны.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Фамилия персоны.
        /// </summary>
        public string Surname { get; private set; }

        /// <summary>
        /// Возраст персоны (должен быть >= 0).
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Пол персоны.
        /// </summary>
        public Sex Sex { get; private set; }

        // === Конструктор ===

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// </summary>
        /// <param name="name">Имя (обязательно, только буквы и пробелы).</param>
        /// <param name="surname">Фамилия (обязательно, только буквы и пробелы).</param>
        /// <param name="age">Возраст (должен быть >= 0).</param>
        /// <param name="sex">Пол персоны.</param>
        /// <exception cref="ArgumentException">Если данные некорректны.</exception>
        /// <exception cref="ArgumentNullException">Если имя или фамилия равны null.</exception>
        public Person(string name, string surname, int age, Sex sex)
        {
            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.", nameof(age));

            Name = EnsureCorrectName(name);
            Surname = EnsureCorrectName(surname);
            Age = age;
            Sex = sex;
        }

        // === Вспомогательные методы ===

        /// <summary>
        /// Приводит имя или фамилию к корректному виду: первая буква — заглавная, остальные — строчные.
        /// Поддерживает двойные имена/фамилии (например, "Иван Петров").
        /// Проверяет, что строка содержит только буквы и пробелы.
        /// </summary>
        /// <param name="input">Входная строка.</param>
        /// <returns>Исправленная строка.</returns>
        /// <exception cref="ArgumentException">Если строка пустая или содержит недопустимые символы.</exception>
        private static string EnsureCorrectName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Имя или фамилия не могут быть пустыми.", nameof(input));

            // Разрешены только буквы (русские и английские) и пробелы
            if (!Regex.IsMatch(input, @"^[\p{L} ]+$"))
                throw new ArgumentException("Имя или фамилия должны содержать только буквы и пробелы.", nameof(input));

            return string.Join(" ", input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(part => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(part.ToLower())));
        }

        // === Публичные статические методы ===

        /// <summary>
        /// Считывает данные о персоне с клавиатуры.
        /// </summary>
        /// <returns>Новый экземпляр <see cref="Person"/>.</returns>
        public static Person ReadFromConsole()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите возраст: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
                throw new FormatException("Возраст должен быть целым числом.");

            Console.WriteLine("Выберите пол:");
            Console.WriteLine("  0 — Мужской");
            Console.WriteLine("  1 — Женский");
            Console.Write("Ваш выбор (0/1): ");
            if (!int.TryParse(Console.ReadLine(), out int genderChoice) || genderChoice < 0 || genderChoice > 1)
                throw new ArgumentException("Некорректный ввод пола. Используйте 0 или 1.");

            Sex sex = genderChoice == 0 ? Sex.Male : Sex.Female;

            return new Person(name, surname, age, sex);
        }

        /// <summary>
        /// Генерирует случайную персону с валидными данными.
        /// </summary>
        /// <returns>Новый экземпляр <see cref="Person"/> с случайными данными.</returns>
        public static Person GetRandomPerson()
        {
            var random = new Random();
            string[] maleNames = { "Алексей", "Дмитрий", "Сергей", "Иван", "Максим", "Артём" };
            string[] femaleNames = { "Анна", "Мария", "Екатерина", "Ольга", "Дарья", "Полина" };
            string[] surnames = { "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов" };

            int age = random.Next(0, 100);
            Sex gender = random.Next(2) == 0 ? Sex.Male : Sex.Female;
            string name = gender == Sex.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];
            string surname = surnames[random.Next(surnames.Length)];

            return new Person(name, surname, age, gender);
        }

        // === Публичные методы экземпляра ===

        /// <summary>
        /// Выводит информацию о персоне на консоль.
        /// </summary>
        public void Display()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Возвращает строковое представление персоны.
        /// </summary>
        /// <returns>Строка вида "Имя Фамилия, N лет, пол: Male/Female".</returns>
        public override string ToString()
        {
            return $"{Name} {Surname}, {Age} лет, пол: {Sex}";
        }
    }
  }