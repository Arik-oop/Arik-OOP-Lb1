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
                // Создаём двух персон
                var person1 = new Person("Алексей", "Иванов", 25, Sex.Male);
                var person2 = new Person("Мария", "Петрова", 30, Sex.Female);

                // Выводим на экран
                Console.WriteLine(person1);
                Console.WriteLine(person2);

                // Попытка создать персону с отрицательным возрастом (должна вызвать исключение)
                var person3 = new Person("Тест", "Ошибка", -5, Sex.Male);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.Read();
        }
    }
}
