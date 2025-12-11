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
                Console.WriteLine("=== Генерация 5 случайных персон ===");
                var list = new PersonList();
                for (int i = 0; i < 5; i++)
                {
                    var person = Person.GetRandomPerson();
                    list.Add(person);
                    Console.WriteLine($"{i + 1}: {person}");
                }

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
                Console.Read();
            }
        }
    }
}
