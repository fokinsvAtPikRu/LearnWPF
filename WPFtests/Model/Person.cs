using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFtests.Model
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;                
        }
        public static List<Person> GetItems()
        {
            var items = new List<Person>();
            items.Add(new Person("Иванов", "Иван"));
            items.Add(new Person("Сидоров", "Сидор"));
            items.Add(new Person("Петров", "Петр"));
            return items;
        }

    }
}
