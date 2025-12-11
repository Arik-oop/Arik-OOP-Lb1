using ARLb1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARLb1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // a. Создаём два списка по три человека
                var list1 = new PersonList();
                var list2 = new PersonList();

                list1.Add(new Person("Алексей", "Иванов", 25, Sex.Male));
                list1.Add(new Person("Мария", "Петрова", 30, Sex.Female));
                list1.Add(new Person("Сергей", "Сидоров", 40, Sex.Male));

                list2.Add(new Person("Анна", "Кузнецова", 22, Sex.Female));
                list2.Add(new Person("Дмитрий", "Морозов", 35, Sex.Male));
                list2.Add(new Person("Елена", "Волкова", 28, Sex.Female));

                // b. Вывод содержимого списков
                Console.WriteLine("=== Список 1 ===");
                PrintList(list1);
                Console.WriteLine("\n=== Список 2 ===");
                PrintList(list2);
                Pause();

                // c. Добавляем нового человека в первый список
                list1.Add(new Person("Ольга", "Новикова", 33, Sex.Female));
                Console.WriteLine("\n→ Добавлен человек в Список 1");
                PrintList(list1);
                Pause();

                // d. Копируем второго человека из list1 в list2
                var personToCopy = list1.Get(1); // Мария Петрова
                list2.Add(personToCopy);
                Console.WriteLine("\n→ Скопирован второй человек из Списка 1 в Список 2");
                Console.WriteLine("Список 2 теперь содержит:");
                PrintList(list2);
                Pause();

                // e. Удаляем второго человека из первого списка
                list1.RemoveAt(1);
                Console.WriteLine("\n→ Удалён второй человек из Списка 1");
                Console.WriteLine("Список 1:");
                PrintList(list1);
                Console.WriteLine("\nСписок 2 (проверка: Мария осталась):");
                PrintList(list2);
                Pause();

                // f. Очищаем второй список
                list2.Clear();
                Console.WriteLine("\n→ Список 2 очищен");
                Console.WriteLine($"Список 2 содержит {list2.Count} элементов.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.Read();
        }

        /// <summary>
        /// Вспомогательный метод для вывода всех элементов списка.
        /// </summary>
        static void PrintList(PersonList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}: {list.Get(i)}");
            }
        }

        /// <summary>
        /// Ожидание нажатия клавиши.
        /// </summary>
        static void Pause()
        {
            Console.Read();
        }
    }
}
