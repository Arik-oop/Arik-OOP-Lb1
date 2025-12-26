using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARLb1
{
    /// <summary>
    /// Класс-обёртка над списком объектов Person.
    /// Предоставляет ограниченный и контролируемый интерфейс для работы со списком.
    /// </summary>
    public class PersonList
    {
        // Инкапсулируем внутренний список — он не виден снаружи
        //TODO: XML
        private readonly List<Person> _persons = new List<Person>();

        /// <summary>
        /// Возвращает количество элементов в списке.
        /// </summary>
        public int Count => _persons.Count;

        /// <summary>
        /// Добавляет персону в конец списка.
        /// </summary>
        /// <param name="person">Персона для добавления.</param>
        public void Add(Person person)
        {
            _persons.Add(person ?? throw new ArgumentNullException(nameof(person)));
        }

        /// <summary>
        /// Удаляет указанную персону из списка (первое вхождение).
        /// </summary>
        /// <param name="person">Персона для удаления.</param>
        /// <returns>True, если персона была найдена и удалена; иначе false.</returns>
        public bool Remove(Person person)
        {
            //TODO: {}
            if (person == null)
                return false;
            return _persons.Remove(person);
        }

        /// <summary>
        /// Удаляет персону по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс удаляемого элемента.</param>
        /// <exception cref="ArgumentOutOfRangeException">Если индекс вне диапазона.</exception>
        public void RemoveAt(int index)
        {
            //TODO: {}
            if (index < 0 || index >= _persons.Count)
                //TODO: RSDN
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы списка.");
            _persons.RemoveAt(index);
        }

        /// <summary>
        /// Возвращает персону по указанному индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <returns>Персона по указанному индексу.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если индекс вне диапазона.</exception>
        public Person Get(int index)
        {
            //TODO: {}
            if (index < 0 || index >= _persons.Count)
                //TODO: RSDN
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы списка.");
            return _persons[index];
        }

        /// <summary>
        /// Возвращает индекс указанной персоны в списке.
        /// </summary>
        /// <param name="person">Персона для поиска.</param>
        /// <returns>Индекс персоны, если найдена; иначе -1.</returns>
        public int IndexOf(Person person)
        {
            return _persons.IndexOf(person);
        }

        /// <summary>
        /// Очищает список от всех элементов.
        /// </summary>
        public void Clear()
        {
            _persons.Clear();
        }

        /// <summary>
        /// Возвращает персону по индексу с помощью индексатора (опционально, но удобно).
        /// </summary>
        /// <param name="index">Индекс.</param>
        /// <returns>Персона по индексу.</returns>
        public Person this[int index] => Get(index);
    }
}
