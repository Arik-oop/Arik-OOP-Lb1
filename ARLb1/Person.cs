using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ARLb1
{
    /// <summary>
    /// Класс, описывающий персону: имя, фамилию, возраст и пол.
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        public Person(string name, string surname, int age, Sex sex)
        {
            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.", nameof(age));
            Name = EnsureCorrectName(name);
            Surname = EnsureCorrectName(surname);
            Age = age;
            Sex = sex;
        }

        /// <summary>
        /// Преобразует имя или фамилию к корректному виду:
        /// первая буква — заглавная, остальные — строчные.
        /// Поддерживает двойные имена/фамилии через пробел.
        /// </summary>
        private static string EnsureCorrectName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Имя или фамилия не могут быть пустыми.", nameof(input));

            // Разрешены только буквы (русские и английские) и пробелы
            if (!Regex.IsMatch(input, @"^[\p{L} ]+$"))
                throw new ArgumentException("Имя или фамилия должны содержать только буквы и пробелы.", nameof(input));

            var parts = input.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Length == 0) continue;
                var firstChar = parts[i][0].ToString().ToUpper(CultureInfo.CurrentCulture);
                var rest = parts[i].Substring(1).ToLower(CultureInfo.CurrentCulture);
                parts[i] = firstChar + rest;
            }
            return string.Join(" ", parts);
        }

        /// <summary>
        /// Считывает данные о персоне с клавиатуры с валидацией.
        /// </summary>
        /// <returns>Новый экземпляр Person.</returns>
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
            string genderInput = Console.ReadLine();
            if (!Enum.TryParse(genderInput, out Sex gender) ||
                (gender != Sex.Male && gender != Sex.Female))
            {
                // Альтернативный ввод как строкой
                Console.Write("Повторите ввод (Male/Female или М/Ж): ");
                string altInput = Console.ReadLine()?.Trim();
                if (string.Equals(altInput, "Male", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(altInput, "М", StringComparison.OrdinalIgnoreCase))
                    gender = Sex.Male;
                else if (string.Equals(altInput, "Female", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(altInput, "Ж", StringComparison.OrdinalIgnoreCase))
                    gender = Sex.Female;
                else
                    throw new ArgumentException("Некорректный ввод пола.");
            }

            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Выводит информацию о персоне на консоль.
        /// </summary>
        public void Display()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, {Age} лет, пол: {Sex}";
        }
    }
}