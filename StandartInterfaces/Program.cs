/**
 * простите можно я подвину
 * вот эту горную гряду
 * я катаклизм я извините
 * гряду
 *                   © колик 
 */

using System;
using System.Collections.Generic;

namespace StandartInterfaces
{
    internal class Program
    {
        private static void Main()
        {
            var persons = new List<Person>
            {
                new Person("Пушкин Александр Сергеевич", new DateTime(1799, 6, 6), new DateTime(1837, 2, 10)),
                new Person("Высоцкий Владимир Семёнович", new DateTime(1938, 1, 25), new DateTime(1980, 7, 25)),
                new Person("Есенин Сергей Александрович", new DateTime(1895, 10, 3), new DateTime(1925, 12, 28)),
                new Person("Бродский Иосиф Александрович", new DateTime (1940, 5, 24), new DateTime(1996, 1, 28)),
                new Person("Цветаева Марина Ивановна", new DateTime(1892, 10, 8), new DateTime(1941, 8, 31)),
                new Person("Ахматова Анна Андреевна", new DateTime(1889, 6, 23), new DateTime(1966, 3, 5)),
                new Person("Гумилёв Николай Степанович", new DateTime(1886, 4, 15), new DateTime(1921, 8, 21)),
                new Person("Маяковский Владимир Владимирович", new DateTime(1893, 7, 19), new DateTime(1930, 4, 14))
            };

            ShowPersons(persons, "before sorting:");

            persons.Sort(new Person.LastNameComparer());
            ShowPersons(persons, "sorting by last name:");

            persons.Sort(new Person.AgeComparer());
            ShowPersons(persons, "sorting by age:");

            persons.Sort(new Person.BirthDateComparer());
            ShowPersons(persons, "sorting by birth date:");
        }

        private static void ShowPersons(IEnumerable<Person> persons, String message)
        {
            Console.WriteLine($"\t{message}");
            foreach (var person in persons)
                Console.WriteLine(person);
            Console.WriteLine();
        }
    }
}
