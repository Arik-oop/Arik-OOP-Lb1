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
                Console.WriteLine("=== Ввод персоны с клавиатуры ===");
                var person = Person.ReadFromConsole();
                Console.WriteLine("\n→ Введённая персона:");
                person.Display();

                Console.WriteLine("\n(Нажмите любую клавишу для выхода...)");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Ошибка ввода: {ex.Message}");
                Console.Read();
            }
        }
    }
}
